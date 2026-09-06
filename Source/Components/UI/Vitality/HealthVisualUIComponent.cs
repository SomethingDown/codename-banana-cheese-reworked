using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class HealthVisualUIComponent : Node
{
    [Export] private ProgressBar health_bar_;
    
    private HealthComponent health_component_;

    public override void _Ready()
    {
        health_component_ = this.GetComponent<HealthComponent>();
        if (health_component_ == null) return;

        health_bar_.Modulate = health_bar_.Modulate * new Color(1.0f,1.0f,1.0f,0.0f);
        health_component_.HealthChanged += OnHealthChanged;
        health_bar_.MaxValue = health_component_.max_health;
        OnHealthChanged(health_component_.max_health);
    }




    private void OnHealthChanged(float v)
    {
        health_bar_.Value = v;
    }



}
