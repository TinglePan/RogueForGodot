using RogueForGodot.common;

namespace RogueForGodot.world;

public class NavigationMgr: BaseMgr<NavigationMgr>
{
    private Game _game;
    
    public NavigationMgr(Game game)
    {
        _game = game;
    }
}