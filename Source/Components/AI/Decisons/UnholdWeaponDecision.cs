using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class UnholdWeaponDecision : Decision
{
    private ThreatAwarenessComponent threat_awareness_componnet_;
    private ItemSelectorComponent item_selector_component_;

    public override void _Ready()
    {
        threat_awareness_componnet_ = GetParent().GetComponent<ThreatAwarenessComponent>();
        item_selector_component_ = GetParent().GetComponent<ItemSelectorComponent>();
    }


    public override void Enter()
    {
        intents_component.target_inventory_item = null;
    }

    public override float GetScore()
    {
        bool is_threatened = threat_awareness_componnet_.GetConfirmedThreats().Count > 0;
        bool is_holding_weapon = item_selector_component_.selected_item?.item_type == ItemType.Weapon;

        if ( !is_holding_weapon || is_threatened ) return 0.0f;
        return success_score;
    }
}
