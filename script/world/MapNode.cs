using Godot;

namespace RogueForGodot.world;

public partial class MapNode: Node2D
{
    public Map Map;

    public void Init(Map map)
    {
        Map = map;
    }
}