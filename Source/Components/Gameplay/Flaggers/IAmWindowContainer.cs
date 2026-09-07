using Godot;
using System;

[GlobalClass]
public partial class IAmWindowContainer : Node
{
    public override void _EnterTree()
    {
        CanvasLayer entity = this.GetEntity() as CanvasLayer;
        if (entity == null) return;
        EventsQueue.instance.Publish(new EventWindowContainerRequest(entity));
    }

    public override void _ExitTree()
    {
        EventsQueue.instance.Publish(new EventWindowContainerRequest(null));
    }
}
