using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

[GlobalClass]
public partial class ObjectivesTrackingComponent : Node
{

    private List<ObjectiveResource> accuired_objective_ = new List<ObjectiveResource>();

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
            case EventObjectiveAquired _e:
                OnObjectiveAccuired(_e.objective);
                break;
            case EventHeistLaunched _e:
                OnHeistLaunched();
                break;
            case EventHeistEnded _e:
                OnHeistEnded(_e.state);
                break;
            default:
                break;
        }
    }

    public void OnObjectiveAccuired(ObjectiveResource objective)
    {
        accuired_objective_.Add(objective);
        EventsQueue.instance.Publish(new EventNotificationTransmitted(new NotificationResource
        {
            title = $"Objective accuired!",
            data = $"{objective.name}",
            icon = objective.icon,

        }));
    }

    public void OnHeistLaunched()
    {
        accuired_objective_.Clear();
    }
    public void OnHeistEnded(HeistEndState state)
    {
        if (state == HeistEndState.Fail) return;

        accuired_objective_.ForEach(o=>{EventsQueue.instance.Publish(new EventObjectiveSecureRequest(o));});
    }

}
