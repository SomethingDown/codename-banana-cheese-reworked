using Godot;
using System;

public interface IUse
{
    public bool Use(Node user);
    public bool UseAlternative(Node user);
}
