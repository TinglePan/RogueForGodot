namespace RogueForGodot.common.data_binding;

public struct ValueChangedEventArgs
{
    public string PropertyName;
}

public struct ValueChangedEventDetailedArgs<T>
{
    public string PropertyName;
    public T OldValue;
    public T NewValue;
}