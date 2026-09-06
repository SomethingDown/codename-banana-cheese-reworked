using Godot;
using System;

public class PlayerState
{
    
    static private PlayerState instance_ = new PlayerState();
    static public PlayerState instance => instance_;

    public Action<Node> PlayerChanged;

    public Node player_entity = null;
    public CurrencyComponent banked_currency_component = new CurrencyComponent{initial_currency=100.99f};
    public InventoryComponent banked_inventory_component = new InventoryComponent(); 

    public void SubscribePlayer(Node entity)
    {
        player_entity = entity;
        PlayerChanged?.Invoke(player_entity);
    }
    public void UnsubscribePlayer()
    {
        player_entity = null;
        PlayerChanged?.Invoke(null);

    }
}
