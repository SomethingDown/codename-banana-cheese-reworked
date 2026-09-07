using Godot;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

[GlobalClass]
public partial class UseWeaponDecision : Decision
{
    
    private ThreatAwarenessComponent threat_awareness_componnet_;
    private ItemSelectorComponent item_selector_component_;
    private EntitiesLOSMemoryComponent entities_los_memory_;
    private Node2D entity_;
    private Random random_ = new Random();

    public override void _Ready()
    {
        threat_awareness_componnet_ = GetParent().GetComponent<ThreatAwarenessComponent>();
        item_selector_component_ = GetParent().GetComponent<ItemSelectorComponent>();
        entities_los_memory_ = GetParent().GetComponent<EntitiesLOSMemoryComponent>();
        entity_ = GetParent().GetEntity() as Node2D;
        if (entity_ == null) return;
    }



    public override float GetScore()
    {
        bool is_threatened = threat_awareness_componnet_.GetConfirmedThreats().Count > 0;
        
        bool is_holding_weapon = item_selector_component_.selected_item?.item_type == ItemType.Weapon;
        Node threat_in_los = null;
        threat_awareness_componnet_.GetConfirmedThreats().ToList().ForEach(t =>
        {
            if (entities_los_memory_.GetEntitiesInLOS().Contains(t)) threat_in_los = t;
        });
        
        bool is_threat_in_los = threat_in_los != null;



        if ( !is_holding_weapon || !is_threat_in_los) return 0.0f;
        return success_score;
    }

    public override void Execute()
    {
        Node2D threat_in_los = null;
        threat_awareness_componnet_.GetConfirmedThreats().ToList().ForEach(t =>
        {
            if (entities_los_memory_.GetEntitiesInLOS().Contains(t)) threat_in_los = t as Node2D;
        });
        if (threat_in_los == null) return;

        intents_component.target_looking_rad = (threat_in_los.GlobalPosition - entity_.GlobalPosition).Normalized().Angle();
        intents_component.target_position = threat_in_los.GlobalPosition + (entity_.GlobalPosition - threat_in_los.GlobalPosition).Rotated(Mathf.DegToRad
        (
            GetNextAngle()
        ));
    
    }

    private float time_to_next = 2.0f;
    private float time = 0.0f;
    private float angle = 0.0f;

    private float GetNextAngle()
    {
        time += (float)GetPhysicsProcessDeltaTime();
        if (time >= time_to_next)
        {
            time -= time_to_next;
            time_to_next = random_.NextSingle() * 5.0f;
            angle = (random_.NextSingle()*2 - 1) * 10;
        }
        return angle;
    }

    public override void Enter()
    {
        intents_component.is_started_using = true;

        AsyncUtils.InvokeNextFrame(()=>{intents_component.is_started_using = false;});
    }

    public override void Exit()
    {
        intents_component.target_looking_rad = null;
        intents_component.is_stopped_using = true;
        AsyncUtils.InvokeNextFrame(()=>{intents_component.is_stopped_using = false;});


    }


}
