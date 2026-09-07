using Godot;
using System;

[GlobalClass]
public partial class ChangeLevelInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_;
    public override void OnInteractionInitiated(Node entity)
    {
        if (scene_ == null) return;

        Node2D level_2d = scene_.Instantiate<Node2D>();
        if (level_2d == null) return;

        // EventsQueue.instance.Publish(new EventLevelLoadRequest(level_2d));
        EventsQueue.instance.Publish(new EventHeistEndRequested(HeistEndState.Success));
    }

}
