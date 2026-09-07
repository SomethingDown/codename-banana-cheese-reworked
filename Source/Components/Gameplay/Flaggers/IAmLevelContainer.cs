using Godot;
using System;

[GlobalClass]
public partial class IAmLevelContainer : Node
{
    public override void _EnterTree()
    {
        Node2D entity = this.GetEntity() as Node2D;
        if (entity == null) return;
        EventsQueue.instance.Publish(new EventLevelContainerRequest(entity));
    }

    public override void _ExitTree()
    {
        EventsQueue.instance.Publish(new EventLevelContainerRequest(null));
    }

}
