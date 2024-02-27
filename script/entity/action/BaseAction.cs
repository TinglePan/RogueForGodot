using System;
using System.Collections.Generic;

namespace RogueForGodot.entity.action;

public struct ActionDoneHandlerArgs
{
    public BaseAction.ActionResult Result;
}

public abstract class BaseAction
{

    public enum ActionResult
    {
        Succeeded,
        Failed,
        Refrained,
    }
    
    protected Game Game;
    protected ActionMgr ActionMgr;

    public Dictionary<ActionResult, EventHandler<ActionDoneHandlerArgs>> OnActionDone;
    public ActionResult Result;
    
    protected BaseAction(Game game,
        EventHandler<ActionDoneHandlerArgs> onSucceeded = null,
        EventHandler<ActionDoneHandlerArgs> onFailed = null,
        EventHandler<ActionDoneHandlerArgs> onRefrained = null)
    {
        Game = game;
        ActionMgr = game.ActionMgr;
        OnActionDone = new Dictionary<ActionResult, EventHandler<ActionDoneHandlerArgs>>();
        foreach (ActionResult k in Enum.GetValues(typeof(ActionResult)))
        {
            OnActionDone[k] = delegate { };
        }
        if (onSucceeded != null) OnActionDone[ActionResult.Succeeded] += onSucceeded;
        if (onFailed != null) OnActionDone[ActionResult.Failed] += onFailed;
        if (onRefrained != null) OnActionDone[ActionResult.Refrained] += onRefrained;
    }
    
    public void Perform()
    {
        if (!ActionMgr.HasRegistered(this))
        {
            ActionMgr.Register(this);
        }
        Result = InnerPerform();
        OnActionDone[Result]?.Invoke(this, new ActionDoneHandlerArgs { Result = Result });
    }
    
    protected abstract ActionResult InnerPerform();
}