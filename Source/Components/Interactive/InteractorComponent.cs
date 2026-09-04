using Godot;
using System;
using System.Collections.Generic;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractorComponent : Node
{
    private InteractionSelectorComponent interaction_selector_;
    private ControllerComponent controller_;
    public Interaction interaction;

    public override void _Ready()
    {
        interaction_selector_ = this.GetComponent<InteractionSelectorComponent>();
        controller_ = this.GetComponent<ControllerComponent>();
    }

    public override void _Process(double delta)
    {
        Node2D interactor = this.GetEntity() as Node2D;

        if (controller_.GetStartedInteracting())
        {
            Interaction next = interaction_selector_.GetSelected();
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
}