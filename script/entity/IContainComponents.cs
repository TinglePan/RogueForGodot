using System;
using RogueForGodot.entity.component;

namespace RogueForGodot.entity;

public interface IContainComponents
{
    protected bool RequireComponent<T>(out T component) where T : BaseComponent;
    public bool AddComponent(BaseComponent component);
}