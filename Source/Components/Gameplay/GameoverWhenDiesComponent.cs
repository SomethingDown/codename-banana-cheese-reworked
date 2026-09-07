using Godot;
using System;

public partial class GameoverWhenDiesComponent : Node
{
    [Export] private HealthComponent health_component_;


    public override void _Ready()
    {
        health_component_ = this.GetComponent<HealthComponent>();
        if (health_component_ == null) return;
        health_component_.HealthDepleted += OnHealthDepleated;
    }

    public override void _ExitTree()
    {
        health_component_.HealthDepleted -= OnHealthDepleated;
    }

    public void OnHealthDepleated()
    {
        // EventsQueue.instance.Publish(new EventGameover());
    }


}
