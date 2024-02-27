using System;

namespace RogueForGodot.common;

public class BaseMgr<T> where T : BaseMgr<T>
{
    private static T _instance;
    public static T Instance => _instance ?? throw new Exception("Instance referred to before constructed");

    protected BaseMgr()
    {
        _instance = this as T;
    }
}