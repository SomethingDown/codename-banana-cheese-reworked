using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class HealthDebugComponnet : Node
{
    
    private HealthComponent health_component;

    public override void _Ready()
    {
        health_component = this.GetComponent<HealthComponent>();
        if (health_component == null) return;

        health_component.HealthChanged += f=> EventsQueue.instance.Publish( new EventMessage{message=$"New health: {f}"});
        health_component.HealthDepleted += ()=> EventsQueue.instance.Publish( new EventMessage{message=$"Health depleted"});

    }


}
