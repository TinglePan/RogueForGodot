using Godot;
using RogueForGodot.common.data_binding;

namespace RogueForGodot.test.responsive_ui;

public partial class TestUiController : Node2D
{
	[Export]
	private Label _label1;
	[Export]
	private Label _label2;

	[Export]
	private Label _label3;
	
	private TestData _testData;
	
	public override void _Ready()
	{
		_testData = new TestData();
		// _testData.WatchTestInt((object s, ValueChangedEventArgs e) => _label1.Text = $"l1{e.PropertyName}:{_testData.TestInt}");
		// _testData.WatchTestInt((object s, ValueChangedEventDetailedArgs<int> e) => _label2.Text = $"l1:{e.OldValue}/{e.NewValue}");
		
		_testData.TestInt.DetailedValueChanged += (object s, ValueChangedEventDetailedArgs<int> e) => _label1.Text = $"l1:{e.OldValue}/{e.NewValue}";
		_testData.TestInt2.DetailedValueChanged += (object s, ValueChangedEventDetailedArgs<int> e) => _label2.Text = $"l2:{e.OldValue}/{e.NewValue}";
		_testData.TestSum.ValueChanged += (object s, ValueChangedEventArgs e) => _label3.Text = $"sum:{_testData.TestSum.Value}";
	}
	
	public void TestMethod()
	{
		_testData.TestInt.Value++;
	}

	public void TestMethod2()
	{
		_testData.TestInt2.Value++;
	}
}
