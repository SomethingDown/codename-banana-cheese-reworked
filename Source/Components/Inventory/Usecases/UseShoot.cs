using Godot;
using System;

[GlobalClass]
public partial class UseShoot : Node, IUse
{

    [Signal] public delegate void ShotEventHandler();

    [Export] public PackedScene projectile_scene;
    [Export] public float cooldown;
    [Export] public Marker2D muzzle;

    private float cooldown_time_=0.0f; 
    private bool is_shooting_;


    public bool UseInitiaited(Node user)
    {
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
            Shoot();
            cooldown_time_ = 0.0f;

        }
    }

    private void Shoot()
    {
        Node2D projectile = projectile_scene.Instantiate() as Node2D;
        if(projectile == null) return;

        projectile.GlobalRotation = muzzle.GlobalRotation; 
        projectile.GlobalPosition = muzzle.GlobalPosition;
        GetTree().CurrentScene.AddChild(projectile);
        EmitSignal(SignalName.Shot);
    }


}
