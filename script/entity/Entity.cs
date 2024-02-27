using System;
using System.Collections.Generic;
using Godot;
using RogueForGodot.entity.component;

namespace RogueForGodot.entity;

public class Entity: IContainComponents
{
    private Game _game;
    private Node2D _node;
    private Dictionary<Type, BaseComponent> _components;
    
    public Game Game => _game;
    
    public Entity(Game game)
    {
        _game = game;
        _components = new Dictionary<Type, BaseComponent>();
    }

    protected void Bind(Node2D node)
    {
        _node = node;
    }
    
    protected bool IsBound => _node != null;
    
    
    public T GetComponent<T>() where T: BaseComponent
    {
        var type = typeof(T);
        if (_components.ContainsKey(type))
        {
            return _components[type] as T;
        }
        foreach (var maybeDerivedType in _components.Keys)
        {
            if (maybeDerivedType.IsSubclassOf(type))
            {
                return _components[maybeDerivedType] as T;
            }
        }
        return default;
    }
    
    public bool RequireComponent<T>(out T component) where T : BaseComponent
    {
        component = GetComponent<T>();
        return component != null;
    }

    public bool AddComponent(BaseComponent component)
    {
        var type = component.GetType();
        return _components.TryAdd(type, component);
    }

    public bool RemoveComponent(BaseComponent component)
    {
        var type = component.GetType();
        return _components.Remove(type);
    }
}