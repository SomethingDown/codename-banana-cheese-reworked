using Godot;
using System;

public partial class ItemHeldHud : Control
{
    [Export] private RichTextLabel item_name_label_;
    [Export] private TextureRect item_icon_texture_;
    [Export] private AtlasTexture no_item_texture;

    private ItemSelectorComponent item_selector_;

    public override void _Ready()
    {
        if (item_name_label_ != null) item_name_label_.Visible = false;
        if (item_icon_texture_ != null) item_icon_texture_.Visible = false;

        EventsBus.instance.Subscribe(OnEvent);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
        UnsubscribeSelector();
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventPlayerChanged e_p:
                OnPlayerChanged(e_p.entity);
                break;
            default:
                break;
        }
    }

    public void OnPlayerChanged(Node player)
    {
        UnsubscribeSelector();

        item_name_label_.Visible = false;
        item_icon_texture_.Visible = false;

        if (player == null || !GodotObject.IsInstanceValid(player)) return;

        item_selector_ = player.GetComponentInEntity<ItemSelectorComponent>();
        if (item_selector_ == null) return;

        item_name_label_.Visible = true;
        item_icon_texture_.Visible = true;

        item_selector_.SelectionChanged += OnSelectionChanged;
        OnSelectionChanged(item_selector_.selected_item);
    }

    private void UnsubscribeSelector()
    {
        if (item_selector_ != null)
            item_selector_.SelectionChanged -= OnSelectionChanged;
        item_selector_ = null;
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