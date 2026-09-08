using Godot;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

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
        else if (e is EventHeistEndRequested c)
        {
            OnHeistEnded(c.state);
        }
        else if (e is EventHeistResults results_event)
        {
            OnResultsArrive(results_event.heist_results);
        }
    }

    public void OnHeistAdded(HeistResource res)
    {
        if (res == null) return;
        if (HeistState.instance.GetHeists().Contains(res)) return;

        HeistState.instance.GetHeists().Add(res);
        EventsQueue.instance.Publish(new EventHeistsChanged(HeistState.instance.GetHeists()));
    }

    public void OnHeistUnlocked(HeistResource res)
    {
        if (!HeistState.instance.GetHeists().Contains(res)) return;
        if (HeistState.instance.GetUnlockedHeists().Contains(res)) return;

        HeistState.instance.GetUnlockedHeists().Add(res);
        EventsQueue.instance.Publish(new EventHeistsUnlocked(HeistState.instance.GetUnlockedHeists()));
    }

    public void OnCurrentHeistSet(HeistResource res)
    {
        if (res == null) return;
        if (res == HeistState.instance.GetSelectedHeist()) return;

        HeistState.instance.selected_heist = res;
        EventsQueue.instance.Publish(new EventHeistSelected(res));
    }

    public void OnHeistLaunched(HeistResource res,InventoryComponent inventory)
    {
        Node2D level = res.scene.Instantiate<Node2D>();
        if (level == null) return;

        HeistState.instance.selected_heist = res;
        PlayerState.instance.transfer_Inventory_component.items.AddRange(inventory.items);
        EventsQueue.instance.Publish(new EventLevelLoadRequest(level));
        EventsQueue.instance.Publish(new EventWindowUnloadRequest());
        EventsQueue.instance.Publish(new EventHeistLaunched(res));
    }

    public void OnHeistEnded(HeistEndState state)
    {
        EventsQueue.instance.Publish(new EventHeistEnded(state));
    }

    public void OnResultsArrive(HeistResultResource results)
    {
        if (results == null) return;

        HeistState.instance.GetHeistLog().Add(results);
        
        Control overview = overview_scene_.Instantiate<Control>();
        if (overview==null) return;

        HeistState.instance.selected_heist = null;
        
        EventsQueue.instance.Publish(new EventWindowLoadRequest(overview));
    }

}