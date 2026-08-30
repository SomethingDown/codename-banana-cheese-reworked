using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
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
        bool drop = false;
        Node2D user = this.GetEntity() as Node2D;
        if (item_node == null) return;
        if (controller_.GetIsUsing()) item_useable_components_.ForEach(u =>
        {
            if (drop) u.Use(user);
            else drop = u.Use(user);
        });
        if (controller_.GetIsUsingAlternative()) item_useable_components_.ForEach(u =>
        {
            if (drop) u.UseAlternative(user);
            else drop = u.UseAlternative(user);
        });
        if (drop) item_selector_.RemoveSelectedFromInventory();
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
