using Godot;
using System;

[GlobalClass]
public partial class DeleteTimerComponent : Node
{
    [Export] private float time_to_delete_=1.0f;

    private float time_ = 0.0f;


    public override void _Ready()
    {
        Node entity = this.GetEntity();
        if (entity == null) {QueueFree();return;}
    }


    public override void _PhysicsProcess(double delta)
    {
        time_ += (float)delta;
        if (time_ >= time_to_delete_) this.GetEntity().QueueFree();
    }


}
