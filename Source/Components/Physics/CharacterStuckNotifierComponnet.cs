using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__bell_node.svg")]
public partial class CharacterStuckNotifierComponnet : Node
{
    [Signal] public delegate void CharacterStuckEventHandler();

    [Export] float time_to_notify = 2.0f;

    private CharacterBody2D character_;
    private ControllerComponent controller_;
    private Vector2 character_previous_position_ = Vector2.Zero;
    private float stuck_time_ = 0.0f;

    public override void _Ready()
    {
        character_ = this.GetEntity() as CharacterBody2D;
        controller_ = this.GetComponent<ControllerComponent>();
    }


    public override void _PhysicsProcess(double delta)
    {
        if (character_ == null || controller_ == null) return;

        bool stuck = (character_.GlobalPosition - character_previous_position_).LengthSquared() <= 0.2 && !controller_.GetMovementAxis().IsZeroApprox();

        character_previous_position_ = character_.GlobalPosition;
        if (stuck) stuck_time_ += (float)delta;
        else stuck_time_ = 0.0f;

        if (stuck_time_ >= time_to_notify){
            EmitSignal(SignalName.CharacterStuck);
        EventsQueue.instance.Publish(new EventMessage{message=$"stuck"});
            stuck_time_ -=time_to_notify;
        }
    }


}
