using System;
using Godot;
using RogueForGodot.common.data_binding;

namespace RogueForGodot.entity;

public interface IMoveOnMap: IOnMap
{
    public void MoveTo(Vector2I to);
    
    public void WatchPosition(EventHandler<ValueChangedEventDetailedArgs<Vector2I>> handler);
}