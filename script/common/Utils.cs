using System.Collections.Generic;
using Godot;
using SadRogue.Primitives;

namespace RogueForGodot.common;

public static class Utils
{
    public static IEnumerable<Vector2I> GetLine(Vector2I start, Vector2I end)
    {
        foreach (var point in Lines.GetBresenhamLine(start.X, start.Y, end.X, end.Y))
        {
            yield return new Vector2I(point.X, point.Y);
        }
    }
}