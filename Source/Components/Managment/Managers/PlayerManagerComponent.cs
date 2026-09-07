using Godot;
using System;
using System.Linq;

[GlobalClass]
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
            SubscribePlayer(subscribe_event.entity);
        }
        else if (e is EventPlayerUnsubscribeRequest)
        {
            UnsubscribePlayer();
        }
    }

    public void SubscribePlayer(Node entity)
    {
        if (entity == null) return;

        PlayerState.instance.player_entity = entity;
        EventsQueue.instance.Publish(new EventPlayerChanged(entity));
    }

    public void UnsubscribePlayer()
    {
        PlayerState.instance.player_entity = null;
        EventsQueue.instance.Publish(new EventPlayerChanged(null));
    }
}