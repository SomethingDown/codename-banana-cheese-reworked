using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class InteractorDebugComponent : Node
{
    private InteractablesSelectorComponent interactables_selector_component_;
    private InteractionSelectorComponent interaction_selector_component_;

    public override void _Ready()
    {
        interactables_selector_component_ = this.GetComponent<InteractablesSelectorComponent>();
        interaction_selector_component_ = this.GetComponent<InteractionSelectorComponent>();
        interactables_selector_component_.SelectionChanged += e =>
        {
            EventsQueue.instance.Publish(
                new EventMessage{
                    message=
                    $"Selected Interactable: {e}|{e?.Name}\n"+
                    $"Selected Interaction: {interaction_selector_component_.GetSelected()?.label}"
                }
            );
        
        };
    }




}
