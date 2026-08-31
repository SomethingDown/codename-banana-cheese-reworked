using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__hand_node2d.svg")]
public partial class HandComponent : Node2D
{
    [Signal] public delegate void ItemSelectionChangedEventHandler(Node2D item_node);
    private ItemSelectorComponent item_selector_;
    private ControllerComponent controller_;
    [Export] public Marker2D hand_axel_;
    [Export] public Marker2D item_position;
    public Node2D item_node;
    private List<IUse> item_useable_components_ = new List<IUse>();

    public override void _Ready()
    {
        item_selector_ = this.GetComponent<ItemSelectorComponent>();
        controller_ = this.GetComponent<ControllerComponent>();

        item_selector_.SelectionChanged += OnSelectedItemChanged;
    }

    public override void _Process(double delta)
    {
        Aim();
        Use();
    }

    private void Aim()
    {
        hand_axel_.GlobalRotation = controller_.GetLookingRad();
    }

    private void Use()
    {
        if (item_node == null) return;
        Node2D user = this.GetEntity() as Node2D;
        bool drop = false;

        if (controller_.GetIsStartedUsing())
        {
            bool result = ItemUseInitiated(user);
            if (result) drop = true;
        }

        if (controller_.GetIsStoppedUsing())
        {
            bool result = ItemUseCanceled(user);
            if (result) drop = true;
        }

        if (controller_.GetIsStartedUsingAlternative())
        {
            bool result = ItemUseAlternativeInitiated(user);
            if (result) drop = true;
        }

        if (controller_.GetIsStoppedUsingAlternative())
        {
            bool result = ItemUseAlternativeCanceled(user);
            if (result) drop = true;
        }

        if (drop) item_selector_.RemoveSelectedFromInventory();
    }

    private bool ItemUseInitiated(Node user)
    {
        bool drop = false;
        foreach (IUse u in item_useable_components_)
        {
            if (drop) u.UseInitiaited(user);
            else drop = u.UseInitiaited(user);
        }
        return drop;
    }

    private bool ItemUseCanceled(Node user)
    {
        bool drop = false;
        foreach (IUse u in item_useable_components_)
        {
            if (drop) u.UseCanceled(user);
            else drop = u.UseCanceled(user);
        }
        return drop;
    }

    private bool ItemUseAlternativeInitiated(Node user)
    {
        bool drop = false;
        foreach (IUse u in item_useable_components_)
        {
            if (drop) u.UseAlternativeInitiaited(user);
            else drop = u.UseAlternativeInitiaited(user);
        }
        return drop;
    }

    private bool ItemUseAlternativeCanceled(Node user)
    {
        bool drop = false;
        foreach (IUse u in item_useable_components_)
        {
            if (drop) u.UseAlternativeCanceled(user);
            else drop = u.UseAlternativeCanceled(user);
        }
        return drop;
    }

    private void OnSelectedItemChanged(ItemResource new_item)
    {
        item_node?.QueueFree();
        item_node = null;
        item_useable_components_.Clear();

        if (new_item != null)
        {
            item_node = new_item.item_equipped_scene.Instantiate() as Node2D;
            item_position.AddChild(item_node);
            item_node.GlobalPosition = item_position.GlobalPosition;
            item_node.GetChildren().ToList().ForEach(c =>
            {
                IUse u = c as IUse;
                if (u != null) item_useable_components_.Add(u);
            });
        }
        EmitSignal(SignalName.ItemSelectionChanged);
    }
}