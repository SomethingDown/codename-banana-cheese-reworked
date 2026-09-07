using Godot;
using System;

[GlobalClass]
public partial class UseShoot : Node, IUse
{

    [Signal] public delegate void ShotEventHandler();

    [Export] public PackedScene projectile_scene;
    [Export] public float cooldown;
    [Export] public Marker2D muzzle;
    public ulong user_id;
    private float cooldown_time_=0.0f; 
    private bool is_shooting_;


    public bool UseInitiaited(Node user)
    {
        if (GodotObject.IsInstanceValid(user)) user_id = user.GetInstanceId();
        is_shooting_ = true;
        return false;
    }
    public bool UseCanceled(Node user)
    {
        is_shooting_ = false;
        return false;
    }

    public bool UseAlternativeInitiaited(Node user)=>false;
    public bool UseAlternativeCanceled(Node user)=>false;

    public override void _PhysicsProcess(double delta)
    {
        cooldown_time_ = Mathf.Min(cooldown,cooldown_time_ += (float)delta);
        if (cooldown_time_ < cooldown) return;
        if (is_shooting_)
        {
            Shoot(user_id);
            cooldown_time_ = 0.0f;

        }
    }

    private void Shoot(ulong user_id)
    {
        Node2D projectile = projectile_scene.Instantiate() as Node2D;
        if(projectile == null) return;

        projectile.GlobalRotation = muzzle.GlobalRotation; 
        projectile.GlobalPosition = muzzle.GlobalPosition;
        DamangeDealerComponent p_c = projectile.GetComponentInEntity<DamangeDealerComponent>();
        if (p_c != null) p_c.source_id = user_id;
        GetTree().CurrentScene.AddChild(projectile);
        EmitSignal(SignalName.Shot);
    }


}
