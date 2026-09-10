using Godot;
using System;

[GlobalClass]
public partial class VelocityAnimationParameter : AnimationParameter
{
    [Export] CharacterMovementComponent movement_component;
    public override Vector2 GetValue()
    {
        if (movement_component == null) return Vector2.Zero;
        return movement_component.last_calculated_velocity.Normalized();
    }

}
