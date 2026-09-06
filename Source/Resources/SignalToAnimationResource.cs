using Godot;
using System;

[GlobalClass]
public partial class SignalToAnimationResource : Resource
{
    [Export] public NodePath source_path;
    [Export] public string signal_name;
    [Export] public NodePath animation_player_path;
    [Export] public string animation_name;
}
