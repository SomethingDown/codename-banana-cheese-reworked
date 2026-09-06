using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class InventoryDisplayerUIComponent : Node
{

    [Export] private PackedScene texture_rect_scene_;
    [Export] private Control items_container;

    private InventoryComponent inventory_;


    public override void _Ready()
    {

        inventory_ = this.GetComponent<InventoryComponent>();
        if (inventory_ == null) return;

        if (items_container == null) return;

        inventory_.ItemsChanged += OnItemsChanged;
        OnItemsChanged();
    }


    private void OnItemsChanged()
    {
        ClearContainer();
        int index = 0;
        inventory_.items.ToList().ForEach(i =>
        {
            DisplayItem(i,index++);
        });
    }

    private void ClearContainer()
    {
        items_container.GetChildren().ToList().ForEach(i_c=>i_c.QueueFree());
    }

    private void DisplayItem(ItemResource item,int idx)
    {
        TextureRect item_display = texture_rect_scene_.Instantiate<TextureRect>();

        if (item_display == null) return;

        item_display.Texture = item.icon;

        items_container.AddChild(item_display);
    }



}
