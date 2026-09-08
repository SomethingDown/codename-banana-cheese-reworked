using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class HeistStatsTrackingComponent : Node
{
    public Dictionary<ulong,int> kills_dictionary = new Dictionary<ulong, int>();
    public Dictionary<ulong,float> currency_dictionary = new Dictionary<ulong, float>();
    public ulong captured_player_id = 0;
    public HeistResource current_heist = null;
    public float currency;
    public DateTime start_time;
    public DateTime end_time;

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
        switch (e)
        {
            case EventEntityDead e_d:
                OnDead(e_d);
                break;

            case EventEntityCurrencyChanged e_c:
                OnCurrencyChanged(e_c);
                break;

            case EventPlayerChanged e_p:
                OnPlayerSelected(e_p.entity);
                break;

            case EventHeistLaunched e_l:
                OnHeistLaunched(e_l.heist);
                break;

            case EventHeistEnded e_e:
                OnHeistEnded(e_e.state);
                break;

            default:
                break;
        }
    }

    public void OnPlayerSelected(Node node)
    {
        if (node == null) return;

        captured_player_id = node.GetInstanceId();
    }

    public void OnHeistLaunched(HeistResource res)
    {
        kills_dictionary.Clear();
        currency_dictionary.Clear();
        start_time = DateTime.Now;
        current_heist = res;
    }

    public void OnHeistEnded(HeistEndState state)
    {
        Node player = GodotObject.InstanceFromId(captured_player_id) as Node;
        if (player == null) return;
        
        end_time = DateTime.Now;

        HeistResultResource results = new HeistResultResource
        {
            heist = current_heist,
            start_time = start_time,
            end_time = end_time,
            currency = currency_dictionary.ContainsKey(captured_player_id)?currency_dictionary[captured_player_id]:0,
            kills = kills_dictionary.ContainsKey(captured_player_id)?kills_dictionary[captured_player_id]:0,
            inventory_used = PlayerState.instance.transfer_Inventory_component.Duplicate() as InventoryComponent,
            end_result = state
        };
        Reset();
        EventsQueue.instance.Publish(new EventHeistResults(results));
    }

    public void OnDead(EventEntityDead e_d)
    {
        if (!kills_dictionary.ContainsKey(e_d.killer_id)) kills_dictionary[e_d.killer_id] = 0;

        kills_dictionary[e_d.killer_id]++;

        if (e_d.killer_id==captured_player_id) GD.Print("PLAYER");
    }

    public void OnCurrencyChanged(EventEntityCurrencyChanged e_c)
    {
        if (!currency_dictionary.ContainsKey(e_c.id)) currency_dictionary[e_c.id] = 0;

        currency_dictionary[e_c.id] = e_c.currency;
    }

    public void Reset()
    {
        kills_dictionary.Clear();
        currency_dictionary.Clear();
        captured_player_id = 0;
        current_heist = null;
        currency = 0.0f;
    }

}
