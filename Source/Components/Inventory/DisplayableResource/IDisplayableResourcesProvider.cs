using Godot;
using System;
using System.Collections.Generic;

public interface IDisplayableResourcesProvider
{
	public event Action ResourcesChanged;
    public List<IDisplayableResource> GetResources();
	public int GetCount();
	public IDisplayableResource GetAt(int index);
	public bool HasResource(IDisplayableResource displayable_resource);
}
