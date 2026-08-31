using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class InteractorDebugComponent : Node
{
    private InteractorComponent interactor_component_;
    private InteractablesSelectorComponent interactables_selector_component_;

    public override void _Ready()
    {
        interactor_component_ = this.GetComponent<InteractorComponent>();
        interactables_selector_component_ = this.GetComponent<InteractablesSelectorComponent>();
    }

    public override void _Process(double delta)
    {
        if (interactor_component_ == null || interactables_selector_component_ == null) return;

        EventsQueue.instance.Publish(
            new EventMessage{message=
            $"Selected Interactable: {interactables_selector_component_.selected_entity}|{interactables_selector_component_.selected_entity?.Name}\n"+
            $"Selected Interaction: {interactor_component_.GetHighlightedInteraction()?.label}"
            }
        );
    }


}
