using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__controller_node.svg")]
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
	public virtual bool GetIsStartedUsing()
	{
		return false;
	}
	public virtual bool GetIsStoppedUsing()
	{
		return false;
	}
	public virtual bool GetIsStartedUsingAlternative()
	{
		return false;
	}
	public virtual bool GetIsStoppedUsingAlternative()
	{
		return false;
	}
	public virtual bool GetIsCanceling()
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

	public virtual bool GetIsSwitchingTargetUp()
	{
		return false;
	}

	public virtual bool GetIsSwitchingTargetDown()
	{
		return false;
	}

}
