using Godot;
using System;

[GlobalClass]
public partial class EntityLOSDebugComponent : Node
{
    private EntityDetectorComponent entity_detector_;
    private EntityLOSComponent los_component_;

    public override void _Ready()
    {
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        los_component_ = this.GetComponent<EntityLOSComponent>();
        entity_detector_.EntityAreaEntered += e =>
        {
            EventsQueue.instance.Publish(new EventMessage{message=$"Los: {e}-{los_component_.IsEntityInLOS(e)}"});

        };
    }
}
