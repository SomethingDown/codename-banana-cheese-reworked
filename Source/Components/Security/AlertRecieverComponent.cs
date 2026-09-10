using Godot;

[GlobalClass]
public partial class AlertRecieverComponent : Node
{
    [Signal] public delegate void AlertEventHandler(Node entity,float meter_bonus);

    private ThreatAwarenessComponent threat_awareness_component;

    public override void _Ready()
    {
        threat_awareness_component = this.GetComponent<ThreatAwarenessComponent>();
        if (threat_awareness_component == null) return;

        EventsBus.instance.Subscribe(OnEvent);

    }
    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventAlert _e:
                threat_awareness_component.ExternalConfirmedThreat(_e.threat,_e.bonus);
                break;
            
            default:
                break;
        }
        
    }


}