using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/pixelarticons__human_arms_up_pixel_node.svg")]
public partial class IAmPlayerComponent : Node
{
    public override void _EnterTree()
    {
        Node entity = this.GetEntity();
        if (entity == null) return;
        PlayerState.instance.SubscribePlayer(entity);
    }

    public override void _ExitTree()
    {
        PlayerState.instance.UnsubscribePlayer();
    }


}
