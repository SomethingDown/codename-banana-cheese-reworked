using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__film_slate_node.svg")]
public partial class SignalToAnimationComponent : Node
{
    [Export] private Node source_;
    [Export] private string signal_name_;
    [Export] private AnimationPlayer animation_player_;
    [Export] private string animation_name_;
    public override void _Ready()
    {
        source_.Connect(signal_name_, Callable.From(() => animation_player_.Play(animation_name_)));
    }
}
