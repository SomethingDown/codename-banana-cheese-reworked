using Godot;
using System;
using System.Collections.Generic;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractorComponent : Node
{
    private InteractablesSelectorComponent interactables_selector_;
    private ControllerComponent controller_;
    private List<Interaction> interactions_ = new List<Interaction>();
    private int selected_interaction_index_;
    public Interaction interaction;

    public override void _Ready()
    {
        interactables_selector_ = this.GetComponent<InteractablesSelectorComponent>();
        controller_ = this.GetComponent<ControllerComponent>();

        interactables_selector_.SelectionChanged += OnSelectedEntityChanged;
    }

    public override void _Process(double delta)
    {
        SwitchInteraction();
        Interact();
    }

    public Interaction GetHighlightedInteraction()
    {
        if (interactions_.Count<=selected_interaction_index_) return null;
        return interactions_[selected_interaction_index_];
    }

    private void SwitchInteraction()
    {
        if (interactions_.Count == 0) return;
        if (controller_.GetIsSwitchInteractionUp())
            selected_interaction_index_ = Mathf.PosMod(selected_interaction_index_ + 1, interactions_.Count);
        else if (controller_.GetIsSwitchInteractionDown())
            selected_interaction_index_ = Mathf.PosMod(selected_interaction_index_ - 1, interactions_.Count);
    }

    private void Interact()
    {
        Node2D interactor = this.GetEntity() as Node2D;
        if (controller_.GetStartedInteracting() && interactions_.Count > 0)
        {
            Interaction next = interactions_[selected_interaction_index_];
            if (interaction != next)
            {
                interaction?.Exit(interactor);
                interaction = next;
                interaction?.Enter(interactor);
            }
        }
        else if (controller_.GetStoppedInteracting())
        {
            interaction?.Exit(interactor);
            interaction = null;
        }
    }

    private void OnSelectedEntityChanged(EntityAreaComponent entity_area)
    {
        Node2D interactor = this.GetEntity() as Node2D;
        interaction?.Exit(interactor);
        interaction = null;
        selected_interaction_index_ = 0;

        InteractableComponent interactable = entity_area?.entity?.GetComponentInEntity<InteractableComponent>();
        interactions_ = interactable?.interactions ?? new List<Interaction>();
    }
}