using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class EntityLOSDebugComponent : Node
{    private EntitiesLOSMemoryComponent los_memory_component_;

    public override void _Ready()
    {
        los_memory_component_ = this.GetComponent<EntitiesLOSMemoryComponent>();
    }

    public override void _Process(double delta)
    {
        EventsQueue.instance.Publish(
            new EventMessage{message=$"{string.Join(" ",los_memory_component_.GetEntitiesInLOS().Select(e=>e.Name))}"}
        );
    }

}
