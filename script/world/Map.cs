using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Reflection;
using Godot;
using RogueForGodot.common.constant;
using RogueForGodot.common.data_binding;
using RogueForGodot.entity;

namespace RogueForGodot.world;


public  class Map
{
    public struct TileChangedEventArgs
    {
        public Map Map;
        public Vector2I Position;
    }

    private MapNode _node;
    private Game _game;
    private NavigationMgr _navigationMgr;

    public Guid Id;
    public string Name;
    public string DisplayName;
    public string Description;

    public Vector2I Dimension;
    public bool StartAtTopLeft;

    public Dictionary<Vector2I, Dictionary<Type, List<BaseEntityWrapper>>> Entities;
    
    // Derived
    public Pawn PlayerControllingPawn;
    public ObservableCollection<bool> VisibilityMask;
    public ObservableCollection<bool> ExploredMask;
    public ObservableCollection<bool> TransparencyMask;
    
    public event EventHandler<TileChangedEventArgs> OnTileChanged;
    public event EventHandler<TileChangedEventArgs> OnVisibleTileChanged;
    
    public Map(Game game, string name, string displayName, Vector2I dimension, bool startAtTopLeft=true)
    {
        _game = game;
        _navigationMgr = game.NavigationMgr;
        
        Id = Guid.NewGuid();
        Name = name;
        DisplayName = displayName;
        Dimension = dimension;
        StartAtTopLeft = startAtTopLeft;
        Entities = new Dictionary<Vector2I, Dictionary<Type, List<BaseEntityWrapper>>>();
    }

    public void Bind(MapNode node)
    {
        _node = node;
    }
    
    public Vector2I IndexToCoordinate(int index)
    {
        return new Vector2I(index % Dimension.X, index / Dimension.X); 
    }
    
    public int CoordinateToIndex(Vector2I coordinate)
    {
        return coordinate.X + coordinate.Y * Dimension.X;
    }
    
    public Vector2I DirToDxy(FlagConstants.Direction direction)
    {
        int x, y;
        switch (direction & (FlagConstants.Direction.Down | FlagConstants.Direction.Up))
        {
            case 0:
                y = 0;
                break;
            case FlagConstants.Direction.Down:
                y = -1;
                break;
            case FlagConstants.Direction.Up:
                y = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, "Bitwise operation on FlagConstants.Direction is problematic");
        }
        if (StartAtTopLeft)
        {
            y = -y;
        }
        switch (direction & (FlagConstants.Direction.Left | FlagConstants.Direction.Right))
        {
            case 0:
                x = 0;
                break;
            case FlagConstants.Direction.Left:
                x = -1;
                break;
            case FlagConstants.Direction.Right:
                x = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, "Bitwise operation on direction9 is problematic");
        }
        var dxy = new Vector2I(x, y);
        return dxy;
    }

    public bool CheckMovePath(Vector2I from, Vector2I to, out Vector2I stopAt)
    {
        // TODO: Implement this correctly
        stopAt = to;
        return true;
    }

    public void Spawn(BaseEntityWrapper entity)
    {
        if (entity is not IOnMap onMapEntity)
        {
            GD.PrintErr("Can not spawn entity which does not implement IOnMap");
            return;
        }
        var position = onMapEntity.Position;
        AddEntityTo(entity, position);
        if (entity is IMoveOnMap moveOnMap)
        {
            moveOnMap.WatchPosition((_, args) =>
            {
                var oldPosition = args.OldValue;
                var newPosition = args.NewValue;
                RemoveEntityFrom(entity, oldPosition);
                AddEntityTo(entity, newPosition);
            });
        }
    }

    public void ControlEntity(BaseEntityWrapper entity)
    {
        PlayerControllingPawn = entity as Pawn;
    }

    private void AddEntityTo(BaseEntityWrapper entity, Vector2I position)
    {
        var type = entity.GetType();
        if (!Entities.ContainsKey(position))
        {
            Entities[position] = new Dictionary<Type, List<BaseEntityWrapper>>();
        }
        if (!Entities[position].ContainsKey(type))
        {
            Entities[position][type] = new List<BaseEntityWrapper>();
        }
        Entities[position][type].Add(entity);
    }

    private void RemoveEntityFrom(BaseEntityWrapper entity, Vector2I position)
    {
        var type = entity.GetType();
        if (!Entities.ContainsKey(position)) return;
        if (!Entities[position].ContainsKey(type)) return;
        Entities[position][type].Remove(entity);
    }
}