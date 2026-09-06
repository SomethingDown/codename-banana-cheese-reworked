using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__bus_node.svg")]
public partial class EventsBusUpdaterComponent : Node
{
    public override void _PhysicsProcess(double delta)
    {
        EventsBus.instance.Update();
    }

}
