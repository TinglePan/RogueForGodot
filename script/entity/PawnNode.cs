using Godot;
using RogueForGodot.common.constant;
using RogueForGodot.common.data_binding;

namespace RogueForGodot.entity;

public partial class PawnNode: Node2D
{
    [Export] public Sprite2D SpriteRef;
    [Export] public float MovementTweenTime;
    
    public Pawn Pawn;

    private Tween _currTween;
    
    public void Init(Pawn pawn)
    {
        Pawn = pawn;
        SpriteRef.Texture = Pawn.Sprite;
        pawn.WatchPosition((_, args) =>
        {
            Move(args.NewValue);
        });
        Position = pawn.Position * Configuration.TileSize + SpriteRef.Texture.GetSize() / 2;
    }
    
    public override void _Ready()
    {
        
    }

    private void Move(Vector2I to)
    {
        _currTween?.Kill();
        _currTween = GetTree().CreateTween();
        Vector2 toPos = to * Configuration.TileSize + SpriteRef.Texture.GetSize() / 2;
        _currTween.TweenProperty(this, "position", toPos, MovementTweenTime);
    }
}