using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class ItemTransferUIComponent : Node
{
    [Export] private ItemSelectorComponent source_selector_;
    [Export] private InventoryComponent destination_inventory_;
    [Export] private LabelOptionUI option_button_;

    private ItemResource selected_item_;
    public override void _Ready()
    {
        if (source_selector_ == null || destination_inventory_ == null) return;

        option_button_.Pressed += OnTransferButtonPressed;

        source_selector_.SelectionChanged += i =>
        {
            selected_item_ = i;
        };
    }

    public void OnTransferButtonPressed()
    {
        if (selected_item_ == null) return;
        if (destination_inventory_.HasItem(selected_item_)) destination_inventory_.Remove(selected_item_);
        else destination_inventory_.Add(selected_item_);
        GD.Print(destination_inventory_.items.Count);
    }

}
