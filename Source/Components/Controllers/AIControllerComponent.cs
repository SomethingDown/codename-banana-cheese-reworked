using Godot;
using System;

[GlobalClass]
public partial class AIControllerComponent : ControllerComponent
{
    private NavigationAgentComponent navigation_agent_;
    private CharacterIntentsComponent character_intents_;
    private ItemSelectorSwitchComponent item_selector_switch_;
    private ItemSelectorComponent item_selector_;


    public override void _Ready()
    {
        character_intents_ = this.GetComponent<CharacterIntentsComponent>();
        navigation_agent_ = this.GetComponent<NavigationAgentComponent>();
        item_selector_switch_ = this.GetComponent<ItemSelectorSwitchComponent>();
        item_selector_ = this.GetComponent<ItemSelectorComponent>();
        entity_ = this.GetEntity() as Node2D;
    }

    public override Vector2 GetMovementAxis()
    {
        Vector2? target_position = character_intents_.target_position;
        
        if (target_position == null || entity_ == null) return Vector2.Zero;

        if (navigation_agent_.TargetPosition != (Vector2)target_position)
            navigation_agent_.TargetPosition = (Vector2)target_position;

        if (navigation_agent_.IsTargetReached() || !navigation_agent_.IsTargetReachable())
        {
            character_intents_.target_position = null;
            return Vector2.Zero;
        }

        Vector2 movement_normal = (navigation_agent_.GetNextPathPosition() - entity_.GlobalPosition).Normalized();
        return movement_normal;
    }

    public override float GetLookingRad()
    {
        if (character_intents_.target_looking_rad == null) return 0.0f;

        return (float)character_intents_.target_looking_rad;

    }


    public override bool GetIsSwitchingItemUp()
    {
        ItemResource item = character_intents_.target_inventory_item;
        if (item == null) return false;
        return ! (item == item_selector_.selected_item);        
    }

    public override bool GetIsSwitchingUnarm()
    {
        ItemResource item = character_intents_.target_inventory_item;
        return item == null;
    }

    public override bool GetIsStartedUsing()
    {
        return character_intents_.is_started_using;
    }

    public override bool GetIsStoppedUsing()
    {
        return character_intents_.is_stopped_using;
    }


}
