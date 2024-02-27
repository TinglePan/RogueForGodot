using System;
using RogueForGodot.world;

namespace RogueForGodot.entity.action;

public class StallAction: BaseAction
{
    
    private IMoveOnMap _entity;
    private Map _map;
    
    public StallAction(Game game, IMoveOnMap entity, Map map,
        EventHandler<ActionDoneHandlerArgs> onSucceeded = null,
        EventHandler<ActionDoneHandlerArgs> onFailed = null,
        EventHandler<ActionDoneHandlerArgs> onRefrained = null) : base(game, onSucceeded, onFailed, onRefrained)
    {
        _entity = entity;
        _map = map;
    }

    protected override ActionResult InnerPerform()
    {
        return ActionResult.Succeeded;
    }
}