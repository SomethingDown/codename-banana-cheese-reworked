using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__backpack_node.svg")]
public partial class ItemSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(ItemResource item);

    private InventoryComponent inventory_;

    public ItemResource selected_item {get;private set;} = null;


    public override void _Ready()
    {
        inventory_ = this.GetComponent<InventoryComponent>();
        if (inventory_ == null) return;
        inventory_.ItemsChanged += OnItemsChanged;
    }

    public void SelectAt(int index)
    {
        if (inventory_ == null) return;
        int count = inventory_.GetCount;
        if (count == 0)
        {
            SetSelected(null);
            return;
        }
        int wrapped = Mathf.Wrap(index,0,count);
        EventsQueue.instance.Publish(new EventMessage{message=$"{count} {wrapped}"});
        SetSelected(inventory_.GetAt(wrapped));
    }

    public void SelectNext() => SelectAt(IndexOfSelected() + 1);

    public void SelectPrevious() => SelectAt(IndexOfSelected() - 1);

    public void Unselect() => SetSelected(null);

    public void RemoveSelectedFromInventory()
    {        
        if (inventory_ == null) return;
        inventory_.Remove(selected_item);
    }

    private int IndexOfSelected()
    {
        if (inventory_ == null) return -1;
        return inventory_.items.IndexOf(selected_item);
    }


    private void SetSelected(ItemResource item)
    {
        if (selected_item == item) return;
        selected_item = item;
        EmitSelectionChangedSignal();
    }

    private void EmitSelectionChangedSignal()
    {
        EmitSignal(SignalName.SelectionChanged, selected_item);
    }

    private void OnItemsChanged()
    {
        int index = IndexOfSelected();
        if (index == -1)
        {
            Unselect();
            return;
        }
        SelectAt(index);
    }

}