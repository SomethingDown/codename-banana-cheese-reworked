using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

[GlobalClass]
public partial class AlertComponent : Node
{
    [Export] private float threat_bonus = 50;
    private ThreatAwarenessComponent threat_awareness_component_;

    public override void _Ready()
    {
        threat_awareness_component_ = this.GetComponent<ThreatAwarenessComponent>();
        if (threat_awareness_component_ == null) return;

        threat_awareness_component_.ThreatConfirmed += OnThreatConfirmed;

    }

    public void OnThreatConfirmed(Node threat)
    {
        EventsQueue.instance.Publish( new EventAlertRequest(threat,threat_bonus) );
        
    }

}
