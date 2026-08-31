using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__hand_cursor_node.svg")]
public partial class InteractablesMemoryComponent : Node
{
    [Signal] public delegate void InteractablesChangedEventHandler();
    public List<EntityAreaComponent> interactable_entities {get;private set;} = new List<EntityAreaComponent>();
    private List<EntityAreaComponent> last_interactable_entities_ = new List<EntityAreaComponent>();
    private EntitiesLOSMemoryComponent entities_los_memory;

    public override void _Ready()
    {
        entities_los_memory = this.GetComponent<EntitiesLOSMemoryComponent>();
    }

    public override void _Process(double delta)
    {
        interactable_entities = entities_los_memory.GetEntitiesInLOS()
            .Where(e => e.entity.GetComponentInEntity<InteractableComponent>() != null)
            .ToList();
        if (interactable_entities.Count == last_interactable_entities_.Count && new HashSet<EntityAreaComponent>(interactable_entities).SetEquals(last_interactable_entities_))
            EmitSignal(SignalName.InteractablesChanged);
        last_interactable_entities_ = interactable_entities;
    }


}