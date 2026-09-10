using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class PlayerStateItemSelectorUIComponent : Node
{

    [Export] private PackedScene texture_button_scene_;
    [Export] private Control items_container;

    private ItemSelectorComponent item_selector_;
    private InventoryComponent inventory_;


    public override void _Ready()
    {
        item_selector_ = this.GetComponent<ItemSelectorComponent>();
        if (item_selector_ == null) return;

        inventory_ = PlayerState.instance.banked_inventory_component;

        if (items_container == null) return;

        inventory_.ItemsChanged += OnItemsChanged;
        OnItemsChanged();
    }

    public override void _ExitTree()
    {
        inventory_.ItemsChanged -= OnItemsChanged;
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
        TextureButton item_option = texture_button_scene_.Instantiate<TextureButton>();

        if (item_option == null) return;

        if (items_container == null) return;
        
        if (!GodotObject.IsInstanceValid(items_container)) return; 

        item_option.TextureNormal = item.icon;

        item_option.Pressed += () =>
        {
            item_selector_.SelectAt(idx);
        };


        items_container.AddChild(item_option);
    }



}
