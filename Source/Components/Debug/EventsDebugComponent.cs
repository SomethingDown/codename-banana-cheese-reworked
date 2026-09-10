using System;
using System.ComponentModel;
using System.IO;
using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class EventsDebugComponent :DebugComponent
{
    private Action<Event> action_=null;
    public override void _Ready()
    {
        action_= e =>
            {
                if (enabled)
                GD.Print($"Event resolved-[{e}]");
            };

        EventsBus.instance.Subscribe(
            action_
        );
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(action_);
    }
}