using Godot;
using System;
using System.Reflection.Emit;

public partial class ObjectiveManagerComponent : Node
{


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
            case EventObjectiveSecureRequest _e:
                OnObjectiveSecureRequest(_e.objective);
                break;
            default:
                break;
        }
    }

    public void OnObjectiveSecureRequest(ObjectiveResource objective)
    {
        if (ObjectiveState.instance.Secured_objectives.Contains(objective)) return;

        ObjectiveState.instance.Secured_objectives.Add(objective);
        EventsQueue.instance.Publish(new EventObjectiveSecured(objective));
        NotificationResource notif = new NotificationResource
        {
            title = $"-{objective.name}-",
            data = $"-{objective.description}-",
            icon = objective.icon

        }; 
        EventsQueue.instance.Publish(new EventNotificationTransmitted(notif));

    }


}
