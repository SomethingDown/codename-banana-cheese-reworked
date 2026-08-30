using Godot;
using System;

[GlobalClass]
public partial class PlayerControllerComponent : ControllerComponent
{


	public override Vector2 GetMovementAxis()
	{
		return Input.GetVector("move_left","move_right","move_up","move_down");
	}
	public override bool GetIsUsing()
	{
		return Input.IsActionJustPressed("use");
	}

	public override bool GetIsUsingAlternative()
	{
		return Input.IsActionJustPressed("use_alternative");
	}

    public override bool GetIsSwitchingItemUp()
    {
        return Input.IsActionJustPressed("switch_item_up");
    }

    public override float GetLookingRad()
    {
        if (entity_ == null) return 0.0f;
        Vector2 direction = entity_.GetGlobalMousePosition() - entity_.GlobalPosition;
        return direction.Angle();
    }

    public override Vector2 GetLookingNormal()
    {
        if (entity_ == null) return Vector2.Zero;
        Vector2 direction = entity_.GetGlobalMousePosition() - entity_.GlobalPosition;
        return direction.Normalized();
    }
    public override bool GetIsSwitchingItemDown()
    {
        return Input.IsActionJustPressed("switch_item_down");
    }

    public override bool GetIsSwitchingUnarm()
    {
        return Input.IsActionJustPressed("switch_unarm");
    }

	public override bool GetStartedInteracting()
	{
		return Input.IsActionJustPressed("interact");
	}
	public override bool GetStoppedInteracting()
	{
		return Input.IsActionJustReleased("interact");
	}
	public override bool GetIsSwitchInteractionDown()
	{
		return Input.IsActionJustPressed("switch_interaction_down");
	}

	public override bool GetIsSwitchInteractionUp()
	{
		return Input.IsActionJustPressed("switch_interaction_up");
	}


}
