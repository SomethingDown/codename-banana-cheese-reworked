using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__workspace_desk_node.svg")]
public partial class PlayerManagerComponent : Node
{
    public override void _Ready()
    {
        EventsBus.instance.Subscribe(OnEvent);
    }
    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }

    public void OnEvent(Event e)
    {
        if (e is EventPlayerSubscribeRequest subscribe_event)
        {
            OnSubscribePlayer(subscribe_event.entity);
        }
        else if (e is EventPlayerUnsubscribeRequest)
        {
            OnUnsubscribePlayer();
        }
        else if (e is EventHeistResults results_event)
        {
            OnHeistResults(results_event.heist_results);
        }
    }

    public void OnSubscribePlayer(Node entity)
    {
        if (entity == null) return;

        PlayerState.instance.player_entity = entity;
        EventsQueue.instance.Publish(new EventPlayerChanged(entity));
    }

    public void OnUnsubscribePlayer()
    {
        PlayerState.instance.player_entity = null;
        EventsQueue.instance.Publish(new EventPlayerChanged(null));
    }

    public void OnHeistResults(HeistResultResource heist_result)
    {
        switch (heist_result.end_result)
        {
            case HeistEndState.Success:
                PlayerState.instance.banked_currency_component.AddCurrency(heist_result.currency);
                break;
            case HeistEndState.Fail:
                heist_result.inventory_used.items.ToList().ForEach(
                    PlayerState.instance.banked_inventory_component.Remove
                );
                break;
            default:
                break;
        }
        PlayerState.instance.transfer_Inventory_component.Clear();
    }

}