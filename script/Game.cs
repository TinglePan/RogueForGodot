using System;
using Godot;
using RogueForGodot.entity;
using RogueForGodot.entity.component;
using RogueForGodot.interact;
using RogueForGodot.world;

namespace RogueForGodot;

public struct PlayerTurnEndArgs
{
    
}

public class Game
{
    
    private GameNode _node;

    public NavigationMgr NavigationMgr;
    public InputMgr InputMgr;
    public ActionMgr ActionMgr;

    public int CurrentTurn;
    public BaseInteract CurrentInteract;
    public Map CurrentMap;
    
    public event EventHandler<PlayerTurnEndArgs> OnPlayerTurnEnd = delegate { };

    public Game()
    {
        NavigationMgr = new NavigationMgr(this);
        InputMgr = new InputMgr(this);
        ActionMgr = new ActionMgr(this);
    }

    public void Start()
    {
        CurrentTurn = 0;
        var map = new Map(this, "TestMap", "测试地图", new Vector2I(10, 10));
        _node.InstantiateMap(map);
        // TODO: use tileAtlasCellSize
        var pawn = new Pawn(new Entity(this), map, new Vector2I(1, 1), 
            "res://texture/characters.png", new SliceSpriteInfo { Offset = new Vector2I(0, 0),
                Size = new Vector2I(16, 16) });
        _node.InstantiatePawn(pawn);
        map.ControlEntity(pawn);
        SwitchInteract(new InDungeonInteract(this, map));
    }

    public void Bind(GameNode node)
    {
        _node = node;
        node.OnInput += InputMgr.OnInput;
        node.OnPhysicsProcess += InputMgr.OnPhysicsProcess;
    }

    public void SwitchInteract(BaseInteract interact)
    {
        BaseInteract.Transit(null, interact);
        CurrentInteract = interact;
    }

    public void PlayerTurnEnd()
    {
        CurrentTurn += 1;
        OnPlayerTurnEnd?.Invoke(this, new PlayerTurnEndArgs());
    }
}