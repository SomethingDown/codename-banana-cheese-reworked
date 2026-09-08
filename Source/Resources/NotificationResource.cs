using Godot;
using System;

public partial class NotificationResource : Resource
{
    [Export] public Texture2D icon;
    [Export] public string title;
    [Export] public string data;
}
