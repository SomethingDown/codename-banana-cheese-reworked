using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class HoldWeaponDecision : Decision
{
    private InventoryComponent inventory_component_;
    private ThreatAwarenessComponent threat_awareness_componnet_;
    private ItemSelectorComponent item_selector_component_;

    public override void _Ready()
    {
        inventory_component_ = GetParent().GetComponent<InventoryComponent>();
        threat_awareness_componnet_ = GetParent().GetComponent<ThreatAwarenessComponent>();
        item_selector_component_ = GetParent().GetComponent<ItemSelectorComponent>();
    }


    public override void Enter()
    {
        intents_component.target_inventory_item = inventory_component_.items.FirstOrDefault(i=>i.item_type == ItemType.Weapon);
    }

    public override float GetScore()
    {
        bool has_weapon = inventory_component_.items.Count(i=>i.item_type == ItemType.Weapon) > 0;
        bool is_threatened = threat_awareness_componnet_.GetConfirmedThreats().Count > 0;
        bool is_holding_weapon = item_selector_component_.selected_item?.item_type == ItemType.Weapon;
        
        if ( !has_weapon || !is_threatened || is_holding_weapon ) return 0.0f;
        return success_score;
    }
}
