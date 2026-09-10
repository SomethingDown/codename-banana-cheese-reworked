using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class EntityDetectorDebugComponent : DebugComponent
{

    private EntityDetectorComponent entity_detector_;


    public override void _Ready()
    {
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        entity_detector_.EntityAreaEntered += e =>
        {
            if (enabled)
            EventsQueue.instance.Publish(new EventMessage{message=$"Entered: {
                string.Join(" ",e.GetChildren().Select(n=>n.Name))
            }"});
        };
        entity_detector_.EntityAreaExited += e =>
        {
            if (enabled)
            EventsQueue.instance.Publish(new EventMessage{message=$"Exited: {e}"});
        };


    }

}
