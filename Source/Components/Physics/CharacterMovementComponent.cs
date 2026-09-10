using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__motion_vector_node.svg")]
public partial class CharacterMovementComponent : Node
{
    [Export] public bool enabled = true; 
    [Export] public float speed = 40.0f;
    public Vector2 last_calculated_velocity {get;private set;} = Vector2.Zero;
    private ControllerComponent controller_component_;
    private CharacterBody2D character_body_;

    public override void _Ready()
    {
        controller_component_ = this.GetComponent<ControllerComponent>();
        character_body_ = this.GetEntity() as CharacterBody2D;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (character_body_ == null || controller_component_ == null) return;

        if (!enabled) return;

        Vector2 move_axis = controller_component_.GetMovementAxis();
        Vector2 velocity = move_axis.Normalized() * speed;
        character_body_.Velocity = velocity;
        character_body_.MoveAndSlide();
        last_calculated_velocity = character_body_.Velocity;

    }

}
