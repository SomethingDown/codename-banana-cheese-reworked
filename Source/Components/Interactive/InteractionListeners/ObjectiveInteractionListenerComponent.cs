using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

[GlobalClass]
public partial class ObjectiveInteractionListenerComponent : InteractionListenerComponent
{
    [Signal] public delegate void CollectedEventHandler();
    [Export] private ObjectiveResource objective_;

    public override void OnInteractionInitiated(Node entity)
    {
        if (objective_ == null) return;
        
        EventsQueue.instance.Publish(
            new EventObjectiveAquired(objective_)
        );
        EmitSignal(SignalName.Collected);
    }


}
