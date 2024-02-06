using System;

namespace RogueForGodot.common.data_binding;

public class ObservedProperty<T>: IObservedProperty<T>
{
    private T _value;
    
    public ObservedProperty(string name, T initialValue)
    {
        Name = name;
        _value = initialValue;
    }
    
    public event EventHandler<ValueChangedEventArgs> ValueChanged;
    public event EventHandler<ValueChangedEventDetailedArgs<T>> DetailedValueChanged;

    public string Name { get; }

    public T Value
    {
        get => _value;
        set
        {
            if (Equals(value, _value)) return;
            var oldValue = _value;
            _value = value;
            ValueChanged?.Invoke(this, new ValueChangedEventArgs {PropertyName = Name});
            DetailedValueChanged?.Invoke(this, new ValueChangedEventDetailedArgs<T>
            {
                PropertyName = Name,
                OldValue = oldValue,
                NewValue = value
            });
        }
    }

}