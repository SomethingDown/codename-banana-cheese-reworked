using Godot;
using System;

[GlobalClass]
public partial class EntityDetectorComponent : Area2D
{
    [Signal] public delegate void EntityAreaEnteredEventHandler(EntityAreaComponent entity_area);
    [Signal] public delegate void EntityAreaExitedEventHandler(EntityAreaComponent entity_area);
    
    private EntityAreaComponent self_entity_area;

    public override void _Ready()
    {
        self_entity_area = this.GetComponent<EntityAreaComponent>();
        
        AreaEntered += a=>
        {
            EntityAreaComponent entity_area = a as EntityAreaComponent;
            if(entity_area==null || entity_area == self_entity_area) return;
            EmitSignal(SignalName.EntityAreaEntered,entity_area);
        };
        AreaExited += a=>
        {
            EntityAreaComponent entity_area = a as EntityAreaComponent;
            if(entity_area==null || entity_area == self_entity_area) return;
            EmitSignal(SignalName.EntityAreaExited,entity_area);
        };
    }


}
