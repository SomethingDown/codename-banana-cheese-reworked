using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/pixelarticons__human_arms_up_pixel_node.svg")]
public partial class IAmPlayerComponent : Node
{
    public override void _EnterTree()
    {
        Node entity = this.GetEntity();
        if (entity == null) return;
        EventsQueue.instance.Publish(new EventPlayerSubscribeRequest(entity));
    }

    public override void _ExitTree()
    {
        EventsQueue.instance.Publish(new EventPlayerUnsubscribeRequest());
    }


}
