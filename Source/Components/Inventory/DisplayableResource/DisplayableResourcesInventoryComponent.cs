using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__backpack_node.svg")]
public partial class DisplayableResourcesInventoryComponent : Node , IDisplayableResourcesProvider
{
	public event Action ResourcesChanged;
	
	private List<IDisplayableResource> resources_ = new List<IDisplayableResource>();

    public override void _Ready()
    {
        resources_.Add(GD.Load<ObjectiveResource>("res://Resources/Objectives/TrainingCandyObjective.tres"));
    }


	public List<IDisplayableResource> GetResources() => resources_;
	public int GetCount() => resources_.Count;
	public IDisplayableResource GetAt(int index)
	{
		if (index<0 || index>=GetCount()){return null;}
		return resources_[index];
	}
	public bool HasResource(IDisplayableResource displayable_resource)
	{
		return resources_.Contains(displayable_resource);
	}
	public void Add(IDisplayableResource displayable_resource)
	{
		if (resources_.Contains(displayable_resource)) return;
		resources_.Add(displayable_resource);
		ResourcesChanged?.Invoke();
	}
	public void Remove(IDisplayableResource displayable_resource)
	{
		resources_.Remove(displayable_resource);
		ResourcesChanged?.Invoke();
	}
	public void Clear()
	{
		resources_.Clear();
		ResourcesChanged?.Invoke();
	}
}