using System;
using RogueForGodot.common.constant;
using RogueForGodot.entity;
using RogueForGodot.entity.action;
using RogueForGodot.world;

namespace RogueForGodot.interact;

public class InDungeonInteract: BaseInteract
{
    private Map _map;
    private EventHandler<ActionDoneHandlerArgs> _playerTurnEnd;
    
    public InDungeonInteract(Game game, Map map) : base(game)
    {
        _map = map;
        _playerTurnEnd = (sender, args) => game.PlayerTurnEnd();
    }

    public override void OnEnter(BaseInteract from)
    {
        base.OnEnter(from);
        foreach (var (commandCode, direction) in CommandCode2DirectionMap)
        {
            InputMgr.RegisterCommandHandler(commandCode, HandleDirectionCommand);
            InputMgr.RegisterCommandHandler(commandCode, HandleDirectionCommand, isHold:true);
        }
    }
    
    public override void OnExit(BaseInteract to)
    {
        base.OnExit(to);
        foreach (var (commandCode, direction) in CommandCode2DirectionMap)
        {
            InputMgr.UnregisterCommandHandler(commandCode, HandleDirectionCommand);
            InputMgr.UnregisterCommandHandler(commandCode, HandleDirectionCommand, isHold:true);
        }
    }
    
    private void HandleDirectionCommand(CommandHandlerArgs args)
    {
        var commandCode = args.CommandCode;
        if (!CommandCode2DirectionMap.TryGetValue(commandCode, out var direction)) return;
        if (direction == FlagConstants.Direction.Neutral)
        {
            new StallAction(Game, _map.PlayerControllingPawn, _map, onSucceeded:_playerTurnEnd).Perform();
        }
        else
        {
            new MoveAction(Game, _map.PlayerControllingPawn, _map, direction, onSucceeded:_playerTurnEnd).Perform();
        }
    }
}