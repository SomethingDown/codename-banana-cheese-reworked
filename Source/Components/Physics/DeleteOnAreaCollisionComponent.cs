using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__trash_can_node.svg")]
public partial class DeleteOnAreaCollisionComponent : Node
{

    [Export] private Area2D area2d_;
    private EntityDetectorComponent entity_detector_;
    public override void _Ready()
    {
        if (area2d_ == null) return;
        area2d_.AreaEntered += a =>
        {
            this.GetEntity().QueueFree();
        };
        area2d_.BodyEntered += a =>
        {
            this.GetEntity().QueueFree();
        };
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        if (entity_detector_ == null) return;

        entity_detector_.EntityAreaEntered += a =>
        {
            this.GetEntity().QueueFree();
        };
    }


}
