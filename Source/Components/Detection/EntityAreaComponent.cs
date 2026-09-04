using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__human_node2d.svg")]
public partial class EntityAreaComponent : Area2D
{
    public Node entity => this.GetEntity();
    public override void _Ready()
    {
        CollisionLayer = PhysicsLayers.Entities;
        CollisionMask = 0;
    }

}
