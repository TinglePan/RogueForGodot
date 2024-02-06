namespace RogueForGodot.common.data_binding;

public interface IObservedProperty<out T>: INotifyValueChanged
{
    public string Name { get; }
    public T Value { get; }
}