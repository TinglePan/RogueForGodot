using Godot;

namespace RogueForGodot.entity.component;

public class TileRender: Render
{
    public TileSetAtlasSource TileSetAtlasSource;
    public Vector2I Offset;
    
    public TileRender(Entity entity, TileSetAtlasSource source, Vector2I offset) : base(entity)
    {
        TileSetAtlasSource = source;
        Offset = offset;
    }
}