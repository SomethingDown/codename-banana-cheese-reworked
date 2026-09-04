using Godot;
using Godot.Collections;

[GlobalClass]
public partial class SignalToTweenResource : Resource
{
    [Export] public NodePath source_path;
    [Export] public string signal_name;
    [Export] public Array<TweenResource> tween_resources = new Array<TweenResource>();
}