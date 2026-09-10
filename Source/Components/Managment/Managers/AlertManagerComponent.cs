using Godot;
using System;

[GlobalClass]
public partial class AlertManagerComponent : Node
{
    [Export] private bool enabled
    {
        get=>AlertState.instance.is_enabled;
        set{AlertState.instance.is_enabled=value;}
    }
    public override void _Ready()
    {
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
            case EventAlertRequest _e:
                if (enabled) EventsQueue.instance.Publish( new EventAlert(_e.threat,_e.bonus) );
                break;
            case EventAlertStateChangeRequest _e:
                enabled = _e.state;
                EventsQueue.instance.Publish( new EventAlertStateChanged(_e.state));
                string state_in_string = _e.state?"Enabled":"Disabled";
                EventsQueue.instance.Publish(new EventNotificationTransmitted ( 
                    new NotificationResource{title="Important",Description=$"Alert system has been [wave]{state_in_string}"}));
                break;
            default:
                break;
        }

    }

}
