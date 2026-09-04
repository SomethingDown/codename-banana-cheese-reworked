using Godot;
using System;

[GlobalClass]
public partial class EventsBusUpdaterComponent : Node
{
    public override void _PhysicsProcess(double delta)
    {
        EventsBus.instance.Update();
    }

}
