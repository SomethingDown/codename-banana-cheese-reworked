using Godot;
using System;

public class PlayerState
{
    static private PlayerState instance_ = new PlayerState();
    static public PlayerState instance => instance_;

    public Node player_entity = null;
    public CurrencyComponent banked_currency_component = new CurrencyComponent();
    public InventoryComponent banked_inventory_component = new InventoryComponent();
    public InventoryComponent transfer_Inventory_component = new InventoryComponent();
}