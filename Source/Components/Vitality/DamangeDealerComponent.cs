using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__sword_node.svg")]
public partial class DamangeDealerComponent : Node
{
    [Export] public float cooldown = 0.5f;
    [Export] public float damage = 10.0f;
    private EntityDetectorComponent entity_detector_;
    private ProjectileComponent projectile_component_;
    private Dictionary<DamageRecieverComponent,float> damage_reciever_component_cooldowns_ = new Dictionary<DamageRecieverComponent, float>();
    
    public override void _Ready()
    {
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        if (entity_detector_ == null) return;
        entity_detector_.EntityAreaEntered += e =>
        {
            DamageRecieverComponent damage_reciever_ = e.GetComponentInEntity<DamageRecieverComponent>();
            if (damage_reciever_ == null) return;

            damage_reciever_component_cooldowns_[damage_reciever_] = cooldown;
        };
        entity_detector_.EntityAreaExited += e =>
        {
            DamageRecieverComponent damage_reciever_ = e.GetComponentInEntity<DamageRecieverComponent>();
            if (damage_reciever_ == null) return;

            damage_reciever_component_cooldowns_.Remove(damage_reciever_);
        };
        projectile_component_ = this.GetComponent<ProjectileComponent>();

    }


    public override void _PhysicsProcess(double delta)
    {
        if (entity_detector_ == null) return;

        damage_reciever_component_cooldowns_.ToList().ForEach(kv =>
        {
            damage_reciever_component_cooldowns_[kv.Key] += (float)delta;
            if(kv.Value < cooldown) return;
            Vector2 impact_velocity = projectile_component_==null?Vector2.Zero:projectile_component_.velocity;
            kv.Key.Damage(damage,impact_velocity);
            damage_reciever_component_cooldowns_[kv.Key] -= cooldown;

        });

    }

}
