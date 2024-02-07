using System;
using System.Collections.Generic;
using RogueForGodot.common;

namespace RogueForGodot.ecs;

public struct Archetype
{
    public ArchetypeId Id;
    public EntityType Type;
    public EcsColumn Components;
    public Dictionary<ComponentId, ArchetypeEdge> Edges;
}