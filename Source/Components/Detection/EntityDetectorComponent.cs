using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__eye_node2d.svg")]
public partial class EntityDetectorComponent : Area2D
{
    [Signal] public delegate void EntityAreaEnteredEventHandler(Node entity);
    [Signal] public delegate void EntityAreaExitedEventHandler(Node entity);
    
    private EntityAreaComponent self_entity_area;

    public override void _Ready()
    {
        self_entity_area = this.GetComponent<EntityAreaComponent>();

        CollisionMask = PhysicsLayers.Entities;
        CollisionLayer = 0;

        AreaEntered += a =>
        {
            EntityAreaComponent entity_area = a as EntityAreaComponent;
            if (entity_area == null || entity_area == self_entity_area) return;
            EmitSignal(SignalName.EntityAreaEntered, entity_area.entity);
        };
        AreaExited += a=>
        {
            EntityAreaComponent entity_area = a as EntityAreaComponent;
            if(entity_area==null || entity_area == self_entity_area) return;
            EmitSignal(SignalName.EntityAreaExited,entity_area.entity);
        };
    }


}
