using Godot;
using System;
using System.Runtime.Serialization;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__medical_cross_sign_healthcare_node.svg")]
public partial class HealthComponent : Node
{
    [Signal] public delegate void HealthChangedEventHandler(float health);
    [Signal] public delegate void HealthDepletedEventHandler();

    [Export] public float max_health = 100.0f;
    [Export] public bool is_immortal = false;
    float health_;
    private DamageRecieverComponent damage_reciever_component_;
    public override void _Ready()
    {
        damage_reciever_component_ = this.GetComponent<DamageRecieverComponent>();
        if (damage_reciever_component_==null) return;

        health_ = max_health;
        damage_reciever_component_.Damaged += (d, i_v) =>
        {
            Damage(d);
        };
    }


    public void Damage(float damage)
    {
        if (damage<=0 || is_immortal) return;

        health_ = Mathf.Max(0,health_ - damage);
        EmitSignal(SignalName.HealthChanged,health_);
        if (health_<=0)
        {
            EventsQueue.instance.Publish(new EventEntityDead(this.GetEntity().Name));
            EmitSignal(SignalName.HealthDepleted);
        }
    }

    public void Heal(float heal)
    {
        if (heal <= 0) return;

        health_ = Mathf.Min(max_health,health_ + heal);
        EmitSignal(SignalName.HealthChanged,health_);
    }

}
