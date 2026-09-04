using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class ThreatEvaluatorDebugComponent : Node
{
    private ThreatEvaluatorComponent threat_evaluator_;
    private ThreatAwarenessComponent threat_awareness_;

    public override void _Ready()
    {

        threat_awareness_ = this.GetComponent<ThreatAwarenessComponent>();
        if (threat_awareness_ != null) 
        {
            threat_awareness_.ThreatConfirmed += e=> 
                EventsQueue.instance.Publish(new EventMessage{message=$"Threat Confirmed: {e.Name}"});
            threat_awareness_.ThreatForgotten += e=> 
                EventsQueue.instance.Publish(new EventMessage{message=$"Threat Forgotten: {e.Name}"});
        }
    
    }

}
