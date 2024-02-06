using System;
using RogueForGodot.common.data_binding;

namespace RogueForGodot.test.responsive_ui;

public class TestData
{
    public ObservedProperty<int> TestInt { get; }
    public ObservedProperty<int> TestInt2 { get; }
    public DerivedObservedProperty<int> TestSum { get; }
    

    public TestData()
    {
        TestInt = new ObservedProperty<int>(nameof(TestInt), 0);
        TestInt2 = new ObservedProperty<int>(nameof(TestInt2), 0);
        TestSum = new DerivedObservedProperty<int>(nameof(TestSum), () => TestInt.Value + TestInt2.Value,
            TestInt, TestInt2);
    }
}