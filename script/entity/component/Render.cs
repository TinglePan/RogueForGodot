using System.Collections.Generic;
using Godot;
using RogueForGodot.entity.component;

namespace RogueForGodot.entity.component;

public abstract class Render: BaseComponent
{
    public enum OutOfSightBehaviour
    {
        None,
        Hide,
        Tint,
    }
    
    public Color GlobalTint;
    public Dictionary<Color, Color> DedicatedTints;
    
    protected Render(Entity entity) : base(entity)
    {
    }
}