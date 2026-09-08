using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__skull_node.svg")]
public partial class DisableBrainOnDeathComponent : Node
{
    private BrainComponent brain_component;
    private HealthComponent health_component;

    public override void _Ready()
    {
        brain_component = this.GetComponent<BrainComponent>();
        if (brain_component == null) return;

        health_component = this.GetComponent<HealthComponent>();
        if (health_component == null) return;

        health_component.HealthDepleted += OnHealthDepleted;
    }

    public void OnHealthDepleted()
    {
        brain_component.enabled = false;
    }

}
