namespace RogueForGodot.ecs;

public struct ArchetypeEdge
{
    public ComponentId ComponentId;
    public Archetype Add;
    public Archetype Remove;
}