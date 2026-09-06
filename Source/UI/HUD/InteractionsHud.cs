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
        PlayerState.instance.PlayerChanged += OnPlayerChanged;
        OnPlayerChanged(PlayerState.instance.player_entity);

    }
    public override void _ExitTree()
    {
        PlayerState.instance.PlayerChanged -= OnPlayerChanged;
    }

    public void OnPlayerChanged(Node player)
    {

        if (player == null) return;

        interactable_selector_ = player.GetComponentInEntity<InteractablesSelectorComponent>();
        if (interactable_selector_ == null) return;

        
        interaction_selector_ = player.GetComponentInEntity<InteractionSelectorComponent>();
        if (interaction_selector_ == null) return;
        
        interactable_selector_.SelectionChanged += OnInteractableChanged;
        OnInteractableChanged(null);
    }

    private void OnInteractableChanged(Node entity)
    {
        interactions_container_.GetChildren().ToList().ForEach(i=>i.QueueFree());
        if (entity == null) return;

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
