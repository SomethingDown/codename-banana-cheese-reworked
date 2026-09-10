using Godot;
using System;

[GlobalClass]
public partial class HeistResource : Resource , IDisplayableResource
{
    [Export] public string name;
    [Export] public string description;
    [Export] public Texture2D icon;
    [Export] public PackedScene scene;

    public string Name {get=>name;set=>name=value;}
    public string Description  {get=>description;set=>description=value;}
    public Texture2D Icon {get=>icon;set=>icon=value;}

}
