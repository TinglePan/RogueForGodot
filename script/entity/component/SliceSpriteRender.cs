using System.Numerics;
using Godot;
using RogueForGodot.entity.component;

namespace RogueForGodot.entity.component;

public struct SliceSpriteInfo
{
    public Vector2I Offset;
    public Vector2I Size;
}

public class SliceSpriteRender: SpriteRender
{
    public SliceSpriteInfo SliceSpriteInfo;
    
    public SliceSpriteRender(Entity entity, Texture2D sprite, SliceSpriteInfo sliceSpriteInfo) : base(entity, sprite)
    {
        var sliceSprite = new AtlasTexture();
        sliceSprite.Atlas = Sprite;
        sliceSprite.Region = new Rect2(sliceSpriteInfo.Offset.X, sliceSpriteInfo.Offset.Y, sliceSpriteInfo.Size.X, 
            sliceSpriteInfo.Size.Y);
        Sprite = sliceSprite;
        SliceSpriteInfo = sliceSpriteInfo;
    }
}