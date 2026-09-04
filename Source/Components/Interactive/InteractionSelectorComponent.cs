using System;
using System.Collections.Generic;
using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractionSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(Interaction interaction);

    private InteractablesSelectorComponent interactables_selector_;
    private ControllerComponent controller_;
    private List<Interaction> interactions_ = new List<Interaction>();
    private int selected_index_;

    public override void _Ready()
    {
        interactables_selector_ = this.GetComponent<InteractablesSelectorComponent>();
        controller_ = this.GetComponent<ControllerComponent>();
        interactables_selector_.SelectionChanged += OnSelectedEntityChanged;
    }

    public override void _Process(double delta)
    {
        if (interactions_.Count == 0) return;
        if (controller_.GetIsSwitchInteractionUp())
            selected_index_ = Mathf.PosMod(selected_index_ + 1, interactions_.Count);
        else if (controller_.GetIsSwitchInteractionDown())
            selected_index_ = Mathf.PosMod(selected_index_ - 1, interactions_.Count);
    }

    public Interaction GetSelected()
    {
        if (interactions_.Count <= selected_index_) return null;
        return interactions_[selected_index_];
    }

    private void OnSelectedEntityChanged(Node entity)
    {
        selected_index_ = 0;
        InteractableComponent interactable = entity?.GetComponentInEntity<InteractableComponent>();
        interactions_ = interactable?.interactions ?? new List<Interaction>();
        EmitSignal(SignalName.SelectionChanged, GetSelected());
    }


}