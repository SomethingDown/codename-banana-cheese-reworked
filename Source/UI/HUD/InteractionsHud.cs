using Godot;
using System;
using System.Linq;

public partial class InteractionsHud : Control
{
    [Export] private PackedScene intreaction_display_scene_;
    [Export] private VBoxContainer interactions_container_;

    private InteractionSelectorComponent interaction_selector_;
    private InteractablesSelectorComponent interactable_selector_;

    public override void _Ready()
    {
        EventsBus.instance.Subscribe(OnEvent);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
        UnsubscribeSelector();
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventPlayerChanged e_p:
                OnPlayerChanged(e_p.entity);
                break;
            default:
                break;
        }
    }

    public void OnPlayerChanged(Node player)
    {
        UnsubscribeSelector();

        if (player == null || !GodotObject.IsInstanceValid(player))
        {
            OnInteractableChanged(null);
            return;
        }

        interactable_selector_ = player.GetComponentInEntity<InteractablesSelectorComponent>();
        if (interactable_selector_ == null) return;

        interaction_selector_ = player.GetComponentInEntity<InteractionSelectorComponent>();
        if (interaction_selector_ == null) return;

        interactable_selector_.SelectionChanged += OnInteractableChanged;
        OnInteractableChanged(null);
    }

    private void UnsubscribeSelector()
    {
        if (interactable_selector_ != null)
            interactable_selector_.SelectionChanged -= OnInteractableChanged;
        interactable_selector_ = null;
    }

    private void OnInteractableChanged(Node entity)
    {
        interactions_container_.GetChildren().ToList().ForEach(i => i.QueueFree());
        if (entity == null || !GodotObject.IsInstanceValid(entity)) return;

        InteractableComponent interactable_component = entity.GetComponentInEntity<InteractableComponent>();
        if (interactable_component == null) return;

        interactable_component.interactions.ForEach(i =>
        {
            InteractionDisplayHud i_d_h = intreaction_display_scene_.Instantiate<InteractionDisplayHud>();
            if (i_d_h == null) return;
            i_d_h.interaction_name = i.label;
            interactions_container_.AddChild(i_d_h);
        });
    }
}