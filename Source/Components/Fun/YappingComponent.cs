using Godot;
using System;

[GlobalClass]
public partial class YappingComponent : Node
{
    public override void _Process(double delta)
    {
        EventsQueue.instance.Publish(new EventMessage{message="I AM YAPPING"});
    }

}
