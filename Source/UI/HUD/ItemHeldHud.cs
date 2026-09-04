using Godot;
using System;

public partial class ItemHeldHud : Control
{
    [Export] private RichTextLabel item_name_label_;
    [Export] private TextureRect item_icon_texture_;
    [Export] private AtlasTexture no_item_texture;


    public override void _Ready()
    {
        Node player = PlayerState.instance.player_entity;
        if (player == null) return;

        ItemSelectorComponent item_selector = player.GetComponentInEntity<ItemSelectorComponent>();
        if(item_selector == null) return;

        item_selector.SelectionChanged += OnSelectionChanged;
        OnSelectionChanged(item_selector.selected_item);
    }

    public void OnSelectionChanged(ItemResource i)
    {
        if (i == null)
        {
            item_name_label_.Text = "Empty";
            item_icon_texture_.Texture = no_item_texture;
            return;
        }
            item_name_label_.Text = i.name;
            item_icon_texture_.Texture = i.icon;
    }

}
