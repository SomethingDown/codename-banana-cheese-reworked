using Godot;
using System;

[GlobalClass]
public partial class EntityAreaComponent : Area2D
{
    public Node entity => this.GetEntity();
}
