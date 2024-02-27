using Godot;
using RogueForGodot.world;

namespace RogueForGodot.entity;

public interface IOnMap
{
    public Vector2I Position { get; }
    public Map Map { get; }
}