using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractablesSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(Node entity);

    private EntitiesLOSMemoryComponent entities_memory_;
    private List<Node> interactables_ => entities_memory_.GetEntitiesInLOSWithComponent<InteractableComponent>();
    public Node selected_entity {get;private set;} = null;

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

    private void SetSelected(Node entity)
    {
        if (selected_entity == entity) return;
        selected_entity?.GetComponentInEntity<InteractableComponent>()?.Unselect();
        selected_entity = entity;
        selected_entity?.GetComponentInEntity<InteractableComponent>()?.Select();
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
            if (interactables_.Count <= 0) {Unselect();return;}
            index = 0;
        }
        SelectAt(index);
    }
}