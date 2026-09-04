using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class FleeDecision : Decision
{

    private ThreatAwarenessComponent threat_awareness_;
    private CharacterStuckNotifierComponnet character_stuck_notifier_;
    private Node2D entity_;
    private Node2D threat_entity_;

    public override void _Ready()
    {   
        entity_ = GetParent().GetEntity() as Node2D;
        if (entity_ == null) return;

        threat_awareness_ = GetParent().GetComponent<ThreatAwarenessComponent>();
        if (threat_awareness_ == null) return;
    
        character_stuck_notifier_ = GetParent().GetComponent<CharacterStuckNotifierComponnet>();
        if (character_stuck_notifier_ == null) return;

        character_stuck_notifier_.CharacterStuck += ResolveStuck;
    }



    public override void Enter()
    {

    }
    public override void Exit()
    {
        intents_component.target_position = null;
    }
    public override float GetScore()
    {
        if (threat_awareness_ == null) return 0.0f;

        threat_entity_ = threat_awareness_.GetConfirmedThreats().FirstOrDefault() as Node2D;

        if (threat_entity_ == null) return 0.0f;

        return success_score;
    }
    public override void Execute()
    {
        if (threat_entity_ == null || entity_ == null) return;

        intents_component.target_position = entity_.GlobalPosition + (entity_.GlobalPosition - threat_entity_.GlobalPosition).Normalized() * 40.0f;
    }

    private void ResolveStuck(){
        
    }


}
