using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/pixelarticons__memory_stick_pixel_node.svg")]
public partial class EntitiesLOSMemoryComponent : Node
{
    [Signal] public delegate void EntitiesChangedEventHandler();
    private EntitiesInRangeMemoryComponent entities_in_range_memory_;
    private EntityLOSComponent entity_los_;
    private List<EntityAreaComponent> entities_;
    private List<EntityAreaComponent> last_entities_ = new List<EntityAreaComponent>();

    public override void _Ready()
    {
        entities_in_range_memory_ = this.GetComponent<EntitiesInRangeMemoryComponent>();
        entity_los_ = this.GetComponent<EntityLOSComponent>();
    }

    public override void _PhysicsProcess(double delta)
    {
        entities_ = entities_in_range_memory_.entities.Where(e=>entity_los_.IsEntityInLOS(e)).ToList();

        bool changed = entities_.Count != last_entities_.Count || !new HashSet<EntityAreaComponent>(entities_).SetEquals(last_entities_);

        last_entities_ = entities_;

        if (changed) EmitSignal(SignalName.EntitiesChanged);
    }


    public List<EntityAreaComponent> GetEntitiesInLOS()
    {
        return entities_;
    }

    public List<EntityAreaComponent> GetEntitiesInLOSWithComponent<T>() where T : class
    {
        return GetEntitiesInLOS().Where(e=>e.entity.GetComponentInEntity<T>() != null).ToList();
    }

}
