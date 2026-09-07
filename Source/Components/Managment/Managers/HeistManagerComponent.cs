using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class HeistManagerComponent : Node
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
        if (e is EventHeistAddRequest add_event)
        {
            AddHeist(add_event.heist);
        }
        else if (e is EventHeistUnlockRequest unlock_event)
        {
            UnlockHeist(unlock_event.heist);
        }
        else if (e is EventHeistSelectRequest select_event)
        {
            SetCurrentHeist(select_event.heist);
        }
    }

    public void AddHeist(HeistResource res)
    {
        if (res == null) return;
        if (HeistState.instance.heists.Contains(res)) return;

        HeistState.instance.heists.Add(res);
        EventsQueue.instance.Publish(new EventHeistsChanged(HeistState.instance.heists));
    }

    public void UnlockHeist(HeistResource res)
    {
        if (!HeistState.instance.heists.Contains(res)) return;
        if (HeistState.instance.unlocked_heists.Contains(res)) return;

        HeistState.instance.unlocked_heists.Add(res);
        EventsQueue.instance.Publish(new EventHeistsUnlocked(HeistState.instance.unlocked_heists));
    }

    public void SetCurrentHeist(HeistResource res)
    {
        if (res == null) return;
        if (res == HeistState.instance.selected_heist) return;

        HeistState.instance.selected_heist = res;
        EventsQueue.instance.Publish(new EventHeistSelected(res));
    }
}