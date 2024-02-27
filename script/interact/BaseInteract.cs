using System.Collections.Generic;
using RogueForGodot.common.constant;

namespace RogueForGodot.interact;

public abstract class BaseInteract
{

    protected static Dictionary<IdConstants.CommandCode, FlagConstants.Direction> CommandCode2DirectionMap = new()
    {
        { IdConstants.CommandCode.Stall, FlagConstants.Direction.Neutral },
        { IdConstants.CommandCode.MoveUp, FlagConstants.Direction.Up },
        { IdConstants.CommandCode.MoveRight, FlagConstants.Direction.Right },
        { IdConstants.CommandCode.MoveDown, FlagConstants.Direction.Down },
        { IdConstants.CommandCode.MoveLeft, FlagConstants.Direction.Left },
        { IdConstants.CommandCode.MoveUpRight, FlagConstants.Direction.UpRight },
        { IdConstants.CommandCode.MoveDownRight, FlagConstants.Direction.DownRight },
        { IdConstants.CommandCode.MoveUpLeft, FlagConstants.Direction.UpLeft },
        { IdConstants.CommandCode.MoveDownLeft, FlagConstants.Direction.DownLeft },
    };
    
    protected Game Game;
    protected InputMgr InputMgr;

    public static void Transit(BaseInteract from, BaseInteract to)
    {
        from?.OnExit(to);
        to?.OnEnter(from);
    }
    
    public virtual void OnEnter(BaseInteract from)
    {
        
    }

    public virtual void OnExit(BaseInteract to)
    {
        
    }

    protected BaseInteract(Game game)
    {
        Game = game;
        InputMgr = game.InputMgr;
    }
    
    public void TransitTo(BaseInteract to)
    {
        Transit(this, to);
    }
}