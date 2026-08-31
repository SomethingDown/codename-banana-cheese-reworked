using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractablesSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(EntityAreaComponent entity_area);

    private EntitiesLOSMemoryComponent entities_memory_;
    private List<EntityAreaComponent> interactables_ => entities_memory_.GetEntitiesInLOSWithComponent<InteractableComponent>();
    public EntityAreaComponent selected_entity {get;private set;} = null;

    public override void _Ready()
    {
        entities_memory_ = this.GetComponent<EntitiesLOSMemoryComponent>();
        entities_memory_.EntitiesChanged += OnInteractablesChanged;
    }

    public void SelectAt(int index)
    {
        int count = interactables_.Count;
        if (count == 0)
        {
            SetSelected(null);
            return;
        }
        int wrapped = Mathf.Wrap(index, 0, count);
        SetSelected(interactables_[wrapped]);
    }

    public void SelectNext() => SelectAt(IndexOfSelected() + 1);

    public void SelectPrevious() => SelectAt(IndexOfSelected() - 1);

    public void Unselect() => SetSelected(null);

    private int IndexOfSelected()
    {
        return interactables_.IndexOf(selected_entity);
    }

    private void SetSelected(EntityAreaComponent entity_area)
    {
        if (selected_entity == entity_area) return;
        selected_entity = entity_area;
        EmitSelectionChangedSignal();
    }

    private void EmitSelectionChangedSignal()
    {
        EmitSignal(SignalName.SelectionChanged, selected_entity);
    }

    private void OnInteractablesChanged()
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