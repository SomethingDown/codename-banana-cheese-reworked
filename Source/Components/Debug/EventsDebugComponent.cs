using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class EventsDebugComponent :Node
{
    public override void _Ready()
    {
        EventsBus.instance.Subscribe(
            e =>
            {
                GD.Print($"Event resolved-[{e}]");
            }
        );
    }
}