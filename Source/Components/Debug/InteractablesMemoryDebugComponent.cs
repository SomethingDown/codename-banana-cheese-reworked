using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class InteractablesMemoryDebugComponent : Node
{
    private InteractablesMemoryComponent interactables_memory_component_;


    public override void _Ready()
    {
        interactables_memory_component_ = this.GetComponent<InteractablesMemoryComponent>();
        interactables_memory_component_.InteractablesChanged += () =>
        {
            EventsQueue.instance.Publish(
                new EventMessage{message=$"interactable changed"}
            );
        };
    }

    


}
