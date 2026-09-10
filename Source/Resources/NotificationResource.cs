using Godot;
using System;

public partial class NotificationResource : Resource , IDisplayableResource
{
    [Export] public string title;
    [Export] public string data;
    [Export] public Texture2D icon;

    public string Name {get=>title;set=>title=value;}
    public string Description  {get=>data;set=>data=value;}
    public Texture2D Icon {get=>icon;set=>icon=value;}

}
