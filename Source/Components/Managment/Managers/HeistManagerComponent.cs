using Godot;
using System;
using System.Linq;
using System.Reflection.Emit;

[GlobalClass]
public partial class HeistManagerComponent : Node
{
    [Export] private PackedScene overview_scene_;

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
            OnHeistAdded(add_event.heist);
        }
        else if (e is EventHeistUnlockRequest unlock_event)
        {
            OnHeistUnlocked(unlock_event.heist);
        }
        else if (e is EventHeistSelectRequest select_event)
        {
            OnCurrentHeistSet(select_event.heist);
        }
        else if (e is EventHeistLaunchRequested launch_event)
        {
            OnHeistLaunched(launch_event.heist,launch_event.transfer_inventory);
        }
        else if (e is EventHeistEndRequested end_event)
        {
            OnHeistEnded();
        }
        else if (e is EventHeistResults results_event)
        {
            OnResultsArive(results_event.heist_results);
        }
    }

    public void OnHeistAdded(HeistResource res)
    {
        if (res == null) return;
        if (HeistState.instance.heists.Contains(res)) return;

        HeistState.instance.heists.Add(res);
        EventsQueue.instance.Publish(new EventHeistsChanged(HeistState.instance.heists));
    }

    public void OnHeistUnlocked(HeistResource res)
    {
        if (!HeistState.instance.heists.Contains(res)) return;
        if (HeistState.instance.unlocked_heists.Contains(res)) return;

        HeistState.instance.unlocked_heists.Add(res);
        EventsQueue.instance.Publish(new EventHeistsUnlocked(HeistState.instance.unlocked_heists));
    }

    public void OnCurrentHeistSet(HeistResource res)
    {
        if (res == null) return;
        if (res == HeistState.instance.selected_heist) return;

        HeistState.instance.selected_heist = res;
        EventsQueue.instance.Publish(new EventHeistSelected(res));
    }

    public void OnHeistLaunched(HeistResource res,InventoryComponent inventory)
    {
        Node2D level = res.scene.Instantiate<Node2D>();
        if (level == null) return;

        HeistState.instance.selected_heist = res;
        PlayerState.instance.transfer_Inventory_component = inventory;
        EventsQueue.instance.Publish(new EventLevelLoadRequest(level));
        EventsQueue.instance.Publish(new EventWindowUnloadRequest());
        EventsQueue.instance.Publish(new EventHeistLaunched(res));
    }

    public void OnHeistEnded()
    {
        HeistState.instance.selected_heist = null;
        PlayerState.instance.transfer_Inventory_component = null;
        EventsQueue.instance.Publish(new EventHeistEnded());
    }

    public void OnResultsArive(HeistResultResource results)
    {
        Control overview = overview_scene_.Instantiate<Control>();
        if (overview==null) return;

        EventsQueue.instance.Publish(new EventWindowLoadRequest(overview));
    }

}