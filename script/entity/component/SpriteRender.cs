using System.Collections.Generic;
using Godot;

namespace RogueForGodot.entity.component;

public class SpriteRender: Render
{
    public Texture2D Sprite;

    public SpriteRender(Entity entity, Texture2D sprite) : base(entity)
    {
        Sprite = sprite;
    }
}