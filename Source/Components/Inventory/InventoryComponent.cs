using System.Linq;
using Godot;
using Godot.Collections;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__backpack_node.svg")]
public partial class InventoryComponent : Node
{
	[Export] public Array<ItemResource> items {get;private set;} = new Array<ItemResource>() ;
	[Signal] public delegate void ItemsChangedEventHandler();

	public int GetCount => items.Count;
	public ItemResource GetAt(int index)
	{
		if (index<0 || index>=GetCount){return null;}
		return items[index];
	}
	public bool HasItemType(ItemType type)
	{
		return items.Select(i=>i.item_type).Contains(type);
	}
	public bool HasItem(ItemResource item_resource)
	{
		return items.Contains(item_resource);
	}
	public void Add(ItemResource item_resource)
	{
		if (items.Contains(item_resource)) return;
		items.Add(item_resource);
		EmitSignal(SignalName.ItemsChanged);
	}
	public void Remove(ItemResource item_resource)
	{
		items.Remove(item_resource);
		EmitSignal(SignalName.ItemsChanged);
	}
}
