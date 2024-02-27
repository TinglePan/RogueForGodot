using System.Collections.Generic;
using RogueForGodot.common;
using RogueForGodot.entity.action;

namespace RogueForGodot;

public class ActionMgr: BaseMgr<ActionMgr>
{
    private Game _game;
    
    protected Queue<int> RecordedTurnIds = new ();
    protected Dictionary<int, Queue<BaseAction>> ActionHistory = new ();
    
    public ActionMgr(Game game): base()
    {
        _game = game;
    }

    public bool HasRegistered(BaseAction action)
    {
        if (!ActionHistory.ContainsKey(_game.CurrentTurn)) return false;
        return ActionHistory[_game.CurrentTurn]?.Contains(action) ?? false;
    }
    
    public void Register(BaseAction action)
    {
        var currentTurn = _game.CurrentTurn;
        if (!RecordedTurnIds.Contains(currentTurn))
        {
            RecordedTurnIds.Enqueue(currentTurn);
            ActionHistory[currentTurn] = new Queue<BaseAction>();
        }
        ActionHistory[currentTurn].Enqueue(action);
    }
}