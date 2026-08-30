using Godot;
using System;

[GlobalClass]
public partial class AIControllerComponent : ControllerComponent
{
    private Node2D entity_;
    private NavigationAgentComponent navigation_agent_;
    private ActorIntentsComponent actor_intents_;
    public override void _Ready()
    {
        actor_intents_ = this.GetComponent<ActorIntentsComponent>();
        navigation_agent_ = this.GetComponent<NavigationAgentComponent>();
        entity_ = this.GetEntity() as Node2D;
    }

    public override Vector2 GetMovementAxis()
    {
        Vector2? target_position = actor_intents_.target_position;
        navigation_agent_.TargetPosition = Vector2.Zero;

        if (target_position == null || entity_ == null) return Vector2.Zero;

        navigation_agent_.TargetPosition = (Vector2)target_position;

        if (navigation_agent_.IsTargetReached() || !navigation_agent_.IsTargetReachable()) return Vector2.Zero;

        Vector2 movement_normal = (navigation_agent_.GetNextPathPosition() - entity_.GlobalPosition).Normalized();
        
        return movement_normal; 
    }

}
