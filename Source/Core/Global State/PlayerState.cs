using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerState
{
    
    static private PlayerState instance_ = new PlayerState();
    static public PlayerState instance => instance_;

    public Action<Node> PlayerChanged;

    public Node player_entity = null;
    public CurrencyComponent banked_currency_component = new CurrencyComponent{};
    public InventoryComponent banked_inventory_component = new InventoryComponent(); 
    public InventoryComponent transfer_Inventory_component = new InventoryComponent();

    public void SubscribePlayer(Node entity)
    {
        player_entity = entity;
        banked_inventory_component.Add(GD.Load<ItemResource>("res://Resources/Items/DrillResource.tres"));
        PlayerChanged?.Invoke(player_entity);
    }
    public void UnsubscribePlayer()
    {
        player_entity = null;
        PlayerChanged?.Invoke(null);

    }
}
