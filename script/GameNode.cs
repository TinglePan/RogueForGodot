using Godot;
using RogueForGodot.entity;
using RogueForGodot.world;

namespace RogueForGodot;

public partial class GameNode : Node
{
	[Export] private PackedScene _mapNodePrefab;
	[Export] private PackedScene _pawnNodePrefab;
	
	private Game _game;
	private MapNode _mapNode;

	[Signal]
	public delegate void OnInputEventHandler(InputEvent @event);
	
	[Signal]
	public delegate void OnPhysicsProcessEventHandler(float delta);
	
	public void InstantiateMap(Map map)
	{
		_mapNode = _mapNodePrefab.Instantiate<MapNode>();
		_mapNode.Init(map);
		AddChild(_mapNode);
	}

	public void InstantiatePawn(Pawn pawn)
	{
		var pawnNode = _pawnNodePrefab.Instantiate<PawnNode>();
		pawnNode.Init(pawn);
		pawn.Map.Spawn(pawn);
		_mapNode.AddChild(pawnNode);
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_game = new Game();
		_game.Bind(this);
		_game.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Input(InputEvent @event)
	{
		EmitSignal(SignalName.OnInput, @event);
	}

	public override void _PhysicsProcess(double delta)
	{
		EmitSignal(SignalName.OnPhysicsProcess, delta);
	}
	
	
}