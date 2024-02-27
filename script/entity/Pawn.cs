using System;
using System.Net.Mime;
using Godot;
using RogueForGodot.common.constant;
using RogueForGodot.common.data_binding;
using RogueForGodot.entity.component;
using RogueForGodot.world;

namespace RogueForGodot.entity;

public class Pawn: BaseEntityWrapper, IMoveOnMap
{
    private OnTileMap _onMap;
    private SpriteRender _render;
    
    public Pawn(Entity e, Map map, Vector2I position, string spritePath, SliceSpriteInfo? sliceSpriteInfo) : base(e)
    {
        _onMap = new OnTileMap(e, map, position);
        e.AddComponent(_onMap);
        var texture = GD.Load<Texture2D>(spritePath);
        _render = sliceSpriteInfo.HasValue ? new SliceSpriteRender(e, texture, sliceSpriteInfo.Value) 
            : new SpriteRender(e, texture);
        e.AddComponent(_render);
    }

    public Map Map => _onMap.Map;
    public Vector2I Position =>_onMap.Position.Value;
    public Texture2D Sprite => _render.Sprite;

    public void MoveTo(Vector2I position)
    {
        _onMap.MoveTo(position);
    }

    public void WatchPosition(EventHandler<ValueChangedEventDetailedArgs<Vector2I>> handler)
    {
        _onMap.Position.DetailedValueChanged += handler;
    }
}