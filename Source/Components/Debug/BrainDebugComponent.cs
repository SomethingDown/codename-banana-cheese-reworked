using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class BrainDebugComponent : Node
{
    private BrainComponent brain_component_;

    public override void _Ready()
    {
        brain_component_ = this.GetComponent<BrainComponent>();
        if (brain_component_ == null) return;

        brain_component_.DecisionChanged += d=> EventsQueue.instance.Publish( new EventMessage{message=$"New decision: {d.Name}"});
    }

    



}
