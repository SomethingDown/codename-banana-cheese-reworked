using Godot;
using System;

public partial class HealthBarHud : Control
{
    [Signal] public delegate void HealthDecreasedEventHandler();
    [Signal] public delegate void HealthIncreasedEventHandler();

    [Export] private ProgressBar health_bar;
    
    public override void _Ready()
    {
        PlayerState.instance.PlayerChanged += OnPlayerChanged;
        OnPlayerChanged(PlayerState.instance.player_entity);
    }
    public override void _ExitTree()
    {
        PlayerState.instance.PlayerChanged -= OnPlayerChanged;
    }


    private void OnPlayerChanged(Node player)
    {
        GD.Print("Player changed: ",player);
        if (health_bar!=null)health_bar.Visible = false;

        if (player == null) return;

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
