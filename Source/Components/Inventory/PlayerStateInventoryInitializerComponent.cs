using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class PlayerStateInventoryInitializerComponent : Node
{
    private InventoryComponent inventory_component_;

    public override void _Ready()
    {
        inventory_component_ = this.GetComponent<InventoryComponent>();
        if (inventory_component_ == null) return;

        PlayerState.instance.transfer_Inventory_component.items.ToList().ForEach(i =>
        {
            inventory_component_.Add(i);
        });
    }


}
