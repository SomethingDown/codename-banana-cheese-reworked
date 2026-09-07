using Godot;
using System;

public partial class HealthBarHud : Control
{
    [Signal] public delegate void HealthDecreasedEventHandler();
    [Signal] public delegate void HealthIncreasedEventHandler();
    [Export] private ProgressBar health_bar;

    public override void _Ready()
    {
        if (health_bar != null) health_bar.Visible = false;
        EventsBus.instance.Subscribe(OnEvent);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventPlayerChanged e_p:
                OnPlayerChanged(e_p.entity);
                break;
            default:
                break;
        }
    }

    private void OnPlayerChanged(Node player)
    {
        if (health_bar != null) health_bar.Visible = false;
        if (player == null) return;
        if (!GodotObject.IsInstanceValid(player)) return;

        health_bar.Visible = true;
        HealthComponent health_component = player.GetComponentInEntity<HealthComponent>();
        if (health_component == null) return;

        health_bar.MaxValue = health_component.max_health;
        health_bar.Value = health_component.max_health;
        health_component.HealthChanged += v =>
        {
            bool is_decreased = health_bar.Value > v;
            if (is_decreased) EmitSignal(SignalName.HealthDecreased);
            else EmitSignal(SignalName.HealthIncreased);
            health_bar.Value = v;
        };
    }
}