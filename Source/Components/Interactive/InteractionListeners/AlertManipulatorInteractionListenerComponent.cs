using Godot;
using System;

[GlobalClass]
public partial class AlertManipulatorInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private bool is_enabler;

    private HackableComponent hackable_component;

    public override void _Ready()
    {
        base._Ready();
        hackable_component = this.GetComponent<HackableComponent>();

    }


    public override void OnInteractionInitiated(Node entity)
    {
        if (hackable_component != null && !hackable_component.IsHacked)
        {
            
            EventsQueue.instance.Publish(new EventNotificationTransmitted(new NotificationResource{title="Warning",Description="Requies [wave]hacking!"}));
            return;
            
        }
        if (AlertState.instance.is_enabled != is_enabler) EventsQueue.instance.Publish(new EventAlertStateChangeRequest(is_enabler));
    }


}
