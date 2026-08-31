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
        interactables_selector_component_.SelectionChanged += e =>
        {
            EventsQueue.instance.Publish(
                new EventMessage{
                    message=
                    $"Selected Interactable: {e}|{e?.Name}\n"+
                    $"Selected Interaction: {interactor_component_.GetHighlightedInteraction()?.label}"
                }
        );  
        };
    }




}
