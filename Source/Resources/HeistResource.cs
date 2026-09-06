using Godot;
using System;

[GlobalClass]
public partial class HeistResource : Resource
{
    [Export] public string name;
    [Export] public string description;
    [Export] public Texture2D icon;
    [Export] public PackedScene scene;

}
