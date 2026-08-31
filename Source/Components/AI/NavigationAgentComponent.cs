using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__navigation_arrow_on_node.svg")]
public partial class NavigationAgentComponent : NavigationAgent2D
{
    [Export] public float desired_distance
    {
        get=>TargetDesiredDistance;
        set=>TargetDesiredDistance=Mathf.Max(8,value);
    }

    public override void _Ready()
    {
        if (desired_distance < 8) desired_distance = 8;
    }

    
}
