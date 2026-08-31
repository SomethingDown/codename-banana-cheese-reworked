using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractablesSelectorSwitchComponent : Node
{
    private ControllerComponent controller_;
    private InteractablesSelectorComponent interactables_selector_;

    public override void _Ready()
    {
        controller_ = this.GetComponent<ControllerComponent>();
        interactables_selector_ = this.GetComponent<InteractablesSelectorComponent>();
    }

    public override void _Process(double delta)
    {
        if (controller_ == null || interactables_selector_ == null) return;
        if (controller_.GetIsSwitchingTargetUp()) interactables_selector_.SelectNext();
        else if (controller_.GetIsSwitchingTargetDown()) interactables_selector_.SelectPrevious();
        else if (controller_.GetIsCanceling()) interactables_selector_.Unselect();
    }
}