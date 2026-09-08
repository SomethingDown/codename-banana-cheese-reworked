using Godot;
using System;


[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class ItemSelectorInfoCardDisplayerUIComponent : Node
{
    [Export] private InfoCardUI info_card_;
    private ItemSelectorComponent item_selector_;

    public override void _Ready()
    {
        item_selector_ = this.GetComponent<ItemSelectorComponent>();
        if (item_selector_ == null) return;

        if (info_card_ == null) return;

        item_selector_.SelectionChanged += (i) =>
        {
            info_card_.title = i.name;
            info_card_.data = i.description;
        };
    }


}
