using Godot;

namespace RogueForGodot.entity.component;

public abstract class BaseComponent
{
    private Entity _entity;
    
    protected BaseComponent(Entity entity)
    {
        _entity = entity;
    }
}