using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__skull_node.svg")]
public partial class DeleteOnDeathComponent : Node
{
    private HealthComponent health_component_;
    public override void _Ready()
    {
        health_component_ = this.GetComponent<HealthComponent>();
        if(health_component_ == null) return;
        health_component_.HealthDepleted += () =>
        {
            this.GetEntity()?.QueueFree();
        };
    }

}
