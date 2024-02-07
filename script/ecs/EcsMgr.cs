using System.Collections.Generic;
using RogueForGodot.common;
using RogueForGodot.ecs.Component;

namespace RogueForGodot.ecs;

public class EcsMgr: BaseMgr<EcsMgr>
{
    public Dictionary<EntityType, Archetype> Archetypes = new();
    public Dictionary<EntityId, EntityRecord> Entities = new();
    
    // public T get_component<T>(EntityId entity, ComponentId component) where T: BaseComponent
    // {
    //     EntityRecord record = Entities[entity];
    //     Archetype archetype = record.Archetype;
    //     // First check if archetype has component
    //     ArchetypeSet archetypes = component_index[component];
    //     if (archetypes.count(archetype.id) == 0) {
    //         return nullptr;
    //     }
    //     for (int i = 0; i < archetype.type.count(); i ++) {
    //         ComponentId type_id = archetype.type[i];
    //         if (type_id == component) {
    //             return archetype.columns[i][record.row];
    //         }
    //     }
    //     return nullptr;
    // }
}