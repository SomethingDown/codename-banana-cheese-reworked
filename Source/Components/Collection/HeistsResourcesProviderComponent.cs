using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class HeistsResourcesProviderComponent : Node, IDisplayableResourcesProvider
{
    
	public event Action ResourcesChanged;

    public override void _Ready()
    {
        EventsBus.instance.Subscribe(OnEvent);
        HeistResource hr = GD.Load<HeistResource>("res://Resources/Heists/TrainingHeist.tres");
        EventsQueue.instance.Publish(new EventHeistAddRequest(hr));
        EventsQueue.instance.Publish(new EventHeistUnlockRequest(hr));
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }


    public void OnEvent(Event e)
    {
        if (e is EventHeistsUnlocked)
        {
            ResourcesChanged?.Invoke();
        }
    }

    public List<IDisplayableResource> GetResources()
    {
        List<IDisplayableResource> displayable_resources = 
            HeistState.instance.unlocked_heists.Select(r=>(IDisplayableResource)r).ToList();
        return displayable_resources;
    }
	public int GetCount() => HeistState.instance.unlocked_heists.Count;
	public IDisplayableResource GetAt(int index)
    {
        return HeistState.instance.unlocked_heists.ElementAtOrDefault(index);
    }

	public bool HasResource(IDisplayableResource displayable_resource)
    {
        return HeistState.instance.unlocked_heists.Any(
            h => h == displayable_resource
        );
    }

}
