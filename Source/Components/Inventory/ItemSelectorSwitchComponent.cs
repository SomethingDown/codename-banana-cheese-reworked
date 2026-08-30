using Godot;
using System;

[GlobalClass]
public partial class ItemSelectorSwitchComponent : Node
{
    private ControllerComponent controller_;
    private ItemSelectorComponent itemSelector_;

    public override void _Ready()
    {
        controller_ = this.GetComponent<ControllerComponent>();
        itemSelector_ = this.GetComponent<ItemSelectorComponent>();
    }


    public override void _Process(double delta)
    {
        if (controller_ == null || itemSelector_ == null) return;
        if (controller_.GetIsSwitchingItemUp())itemSelector_.SelectNext();
        else if (controller_.GetIsSwitchingItemDown())itemSelector_.SelectPrevious();
        else if (controller_.GetIsSwitchingUnarm())itemSelector_.Unselect();
    }

}
