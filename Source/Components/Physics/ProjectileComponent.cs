using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__arrow_projectile_node.svg")]
public partial class ProjectileComponent : Node
{
    [Export] public float speed = 100.0f;
    public Vector2 velocity = Vector2.Zero;
    public override void _PhysicsProcess(double delta)
    {
        Node2D entity = this.GetEntity() as Node2D;
        if (entity == null) return;
        velocity = Vector2.FromAngle(entity.GlobalRotation) * speed * (float)delta;
        entity.Position += velocity;
    }


}
