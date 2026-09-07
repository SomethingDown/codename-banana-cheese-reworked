using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class KillsTrackerComponent : Node
{

    public Dictionary<ulong,int> kills_dictionary = new Dictionary<ulong, int>();

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
                if (!kills_dictionary.ContainsKey(e_d.killer_id))kills_dictionary[e_d.killer_id] = 0;
                kills_dictionary[e_d.killer_id]++;
                break;

            default:
                break;
        }
    }

}
