using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__sword_node.svg")]
public partial class DamangeDealerComponent : Node
{
    [Export] public float cooldown = 0.5f;
    [Export] public float max_damage = 10.0f;
    [Export] public float min_damage = 9.0f;
    public ulong source_id;
    private EntityDetectorComponent entity_detector_;
    private ProjectileComponent projectile_component_;
    private Dictionary<DamageRecieverComponent,float> damage_reciever_component_cooldowns_ = new Dictionary<DamageRecieverComponent, float>();
    private Random random_ = new Random();
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

        max_damage = Mathf.Max(max_damage,min_damage);
    }


    public override void _PhysicsProcess(double delta)
    {
        if (entity_detector_ == null) return;

        damage_reciever_component_cooldowns_.ToList().ForEach(kv =>
        {
            damage_reciever_component_cooldowns_[kv.Key] += (float)delta;
            if(kv.Value < cooldown) return;
            damage(kv.Key);
            damage_reciever_component_cooldowns_[kv.Key] -= cooldown;

        });

    }


    private void damage(DamageRecieverComponent damage_reciever)
    {
        Vector2 impact_velocity = projectile_component_==null?Vector2.Zero:projectile_component_.velocity;
        double damage = Math.Round(min_damage + random_.NextSingle()*(max_damage - min_damage),3);
        damage_reciever.Damage((float)damage,impact_velocity,source_id);
    }

}
