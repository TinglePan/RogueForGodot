using Godot;
using RogueForGodot.common.data_binding;
using RogueForGodot.world;

namespace RogueForGodot.entity.component;

public class OnTileMap: BaseComponent
{
    public Map Map;
    public ObservableProperty<Vector2I> Position;

    public OnTileMap(Entity entity, Map map, Vector2I position) : base(entity)
    {
        Map = map;
        Position = new ObservableProperty<Vector2I>(nameof(Position), position);
    }
    
    public void MoveTo(Vector2I to)
    {
        Position.Value = to;
    }
}