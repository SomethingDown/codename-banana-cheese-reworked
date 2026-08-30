using Godot;
using System;

[GlobalClass]
public partial class ControllerComponent : Node
{
	protected Node2D entity_;

    public override void _Ready()
    {
        entity_ = (Node2D)this.GetEntity();
    }


	public virtual Vector2 GetMovementAxis()
	{
		return Vector2.Zero;
	}
	public virtual bool GetIsUsing()
	{
		return false;
	}
	public virtual float GetLookingRad()
	{
		return 0.0f;
	}
	public virtual Vector2 GetLookingNormal()
	{
		return Vector2.Zero;
	}
	public virtual bool GetIsUsingAlternative()
	{
		return false;
	}
	public virtual bool GetIsSwitchingItemUp()
	{
		return false;
	}
	public virtual bool GetIsSwitchingItemDown()
	{
		return false;
	}
	public virtual bool GetIsSwitchingUnarm()
	{
		return false;
	}
	public virtual bool GetStartedInteracting()
	{
		return false;
	}
	public virtual bool GetStoppedInteracting()
	{
		return false;
	}
	public virtual bool GetIsSwitchInteractionDown()
	{
		return false;
	}

	public virtual bool GetIsSwitchInteractionUp()
	{
		return false;
	}


}
