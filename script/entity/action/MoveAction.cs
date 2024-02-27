using System;
using RogueForGodot.common.constant;
using RogueForGodot.world;

namespace RogueForGodot.entity.action;

public class MoveAction: BaseAction
{
    private IMoveOnMap _entity;
    private Map _map;
    private FlagConstants.Direction _direction;
    
    public MoveAction(Game game, IMoveOnMap entity, Map map, FlagConstants.Direction direction,
        EventHandler<ActionDoneHandlerArgs> onSucceeded = null,
        EventHandler<ActionDoneHandlerArgs> onFailed = null,
        EventHandler<ActionDoneHandlerArgs> onRefrained = null) : base(game, onSucceeded, onFailed, onRefrained)
    {
        _entity = entity;
        _map = map;
        _direction = direction;
    }

    protected override ActionResult InnerPerform()
    {
        var dxy = _map.DirToDxy(_direction);
        var startPos = _entity.Position;
        var destPos = startPos + dxy;
        if (!_map.CheckMovePath(startPos, destPos, out var stopAtPos))
        {
            if (startPos == stopAtPos)
            {
                return ActionResult.Refrained;
            }
            _entity.MoveTo(stopAtPos);
            return ActionResult.Failed;
        }
        _entity.MoveTo(destPos);
        return ActionResult.Succeeded;
    }
}