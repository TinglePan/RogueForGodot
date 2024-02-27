namespace RogueForGodot.common.constant;

public static class IdConstants
{
    public enum CollisionLayerId
    {
        Player,
        Friendly,
        Hostile,
        Obstacle,
        Liquid,
    }

    public enum NavigationLayerId
    {
        Player,
        Friendly,
        Hostile,
        Wall,
        SturdyWall,
        ObstacleFurniture,
        ClosedDoor,
        Water,
        Lava,
    }

    public enum CommandCode
    {
        Stall,
        MoveUp,
        MoveRight,
        MoveDown,
        MoveLeft,
        MoveUpRight,
        MoveDownRight,
        MoveUpLeft,
        MoveDownLeft,
    }
}