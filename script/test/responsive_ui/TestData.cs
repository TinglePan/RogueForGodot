using System;
using RogueForGodot.common.data_binding;

namespace RogueForGodot.test.responsive_ui;

public class TestData
{
	public ObservableProperty<int> TestInt { get; }
	public ObservableProperty<int> TestInt2 { get; }
	public DerivedObservableProperty<int> TestSum { get; }
	

	public TestData()
	{
		TestInt = new ObservableProperty<int>(nameof(TestInt), 0);
		TestInt2 = new ObservableProperty<int>(nameof(TestInt2), 0);
		TestSum = new DerivedObservableProperty<int>(nameof(TestSum), () => TestInt.Value + TestInt2.Value,
			TestInt, TestInt2);
	}
}
