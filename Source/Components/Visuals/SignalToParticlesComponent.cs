using Godot;
using System;

[GlobalClass]
public partial class SignalToParticlesComponent : Node
{
    [Export] private Node source_;
    [Export] private string signal_name_;
    [Export] private GpuParticles2D particles_;

    public override void _Ready()
    {
        source_.Connect(signal_name_, Callable.From(() => particles_.Restart()));
    }
}