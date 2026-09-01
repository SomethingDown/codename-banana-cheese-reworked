using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class UseHack : Node, IUse
{

    public bool UseInitiaited(Node user)
    {
        EntitiesLOSMemoryComponent entities_los_memory_component = user.GetComponentInEntity<EntitiesLOSMemoryComponent>();
        if (entities_los_memory_component == null) return false;
        
        List<EntityAreaComponent> entities = entities_los_memory_component.GetEntitiesInLOSWithComponent<HackableComponent>();
        entities = entities.Where(e=>e.entity.GetComponentInEntity<HackableComponent>().IsHacked==false).ToList();

        if (entities.Count <= 0) return false;

        entities.First().entity.GetComponentInEntity<HackableComponent>().Hack();

        return false;
    }
    public bool UseCanceled(Node user)=>false;

    public bool UseAlternativeInitiaited(Node user)=>false;
    public bool UseAlternativeCanceled(Node user)=>false;

}
