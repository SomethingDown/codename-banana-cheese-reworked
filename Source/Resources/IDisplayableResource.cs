using Godot;
using System;

public interface IDisplayableResource
{
    public string Name {get;set;}
    public string Description {get;set;}
    public Texture2D Icon {get;set;}
}
