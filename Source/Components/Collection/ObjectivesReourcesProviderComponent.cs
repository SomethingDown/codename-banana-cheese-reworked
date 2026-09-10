using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class ObjectivesReourcesProviderComponent : Node , IDisplayableResourcesProvider
{
	public event Action ResourcesChanged;

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
        if (e is EventHeistsUnlocked)
        {
            ResourcesChanged?.Invoke();
        }
    }

    public List<IDisplayableResource> GetResources()
    {
        List<IDisplayableResource> displayable_resources = 
            ObjectiveState.instance.Secured_objectives.Select(r=>(IDisplayableResource)r).ToList();
        return displayable_resources;
    }
	public int GetCount() => ObjectiveState.instance.Secured_objectives.Count;
	public IDisplayableResource GetAt(int index)
    {
        return ObjectiveState.instance.Secured_objectives.ElementAtOrDefault(index);
    }

	public bool HasResource(IDisplayableResource displayable_resource)
    {
        return ObjectiveState.instance.Secured_objectives.Any(
            h => h == displayable_resource
        );
    }

}
