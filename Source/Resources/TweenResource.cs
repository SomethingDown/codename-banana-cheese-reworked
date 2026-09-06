using Godot;
using System;

[GlobalClass]
public partial class TweenResource : Resource
{
    [Export] public NodePath node_path;
    [Export] public bool parallel_to_previous;
    [Export] public string action;
    [Export] public Variant value;
    [Export] public float duration;

}
