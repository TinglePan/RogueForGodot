namespace RogueForGodot;

public class BaseMgr<T> where T : BaseMgr<T>, new()
{
    private static T _instance;
    public static T Instance => _instance ??= new T();
}