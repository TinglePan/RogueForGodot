using System;
using System.Collections.Generic;

namespace RogueForGodot.common;

public class HashList<T>: List<T>, IEquatable<HashList<T>>
{
    public bool Equals(HashList<T> other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        var res = 0;
        for (var index = 0; index < Count; index++)
        {
            var element = this[index];
            res ^= element.GetHashCode();
        }
        return res;
    }
}