using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class EntitiesLOSMemoryComponent : Node
{
    private EntitiesInRangeMemoryComponent entities_in_range_memory_;
    private EntityLOSComponent entity_los_;

    public override void _Ready()
    {
        entities_in_range_memory_ = this.GetComponent<EntitiesInRangeMemoryComponent>();

    }

    public List<EntityAreaComponent> GetEntitiesInLOS()
    {
        List<EntityAreaComponent> entities = new List<EntityAreaComponent>();
        entities_in_range_memory_.entities.ForEach(e =>
        {
            if(entity_los_.IsEntityInLOS(e)) entities.Add(e);
        });
        return entities;
    }


}
