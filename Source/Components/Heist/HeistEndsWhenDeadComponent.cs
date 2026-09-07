using Godot;
using System;

[GlobalClass]
public partial class HeistEndsWhenDeadComponent : Node
{
    private HealthComponent health_component_;

    public override void _Ready()
    {
        health_component_ = this.GetComponent<HealthComponent>();
        if (health_component_ == null) return;

        health_component_.HealthDepleted += OnDead;
    }

    public override void _ExitTree()
    {
        health_component_.HealthDepleted -= OnDead;
    }


    public void OnDead()
    {
        EventsQueue.instance.Publish(new EventHeistEndRequested(HeistEndState.Fail));
    }

}
