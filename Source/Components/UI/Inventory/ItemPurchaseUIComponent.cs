using Godot;
using System;

[GlobalClass]
public partial class ItemPurchaseUIComponent : Node
{
    [Export] private LabelOptionUI label_option_;

    private ItemSelectorComponent item_selector_;

    public override void _Ready()
    {
        item_selector_ = this.GetComponent<ItemSelectorComponent>();
        if (item_selector_ == null) return;

        if (label_option_ == null) return;

        label_option_.button_text = "Buy";

        item_selector_.SelectionChanged += i =>
        {
            label_option_.label_text = $"{i.base_price}$";
        };
        label_option_.Pressed += () =>
        {
            ItemResource item = item_selector_.selected_item;
            if (item == null) return;

            InventoryComponent inventory = PlayerState.instance.banked_inventory_component;
            if (inventory == null) return;

            CurrencyComponent currency = PlayerState.instance.banked_currency_component;
            if (currency == null) return;

            if (!currency.TrySpend(item.base_price)) return;

            inventory.Add(item);
        };
    }

    
}
