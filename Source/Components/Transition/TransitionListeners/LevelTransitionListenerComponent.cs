using Godot;
using System;

[GlobalClass]
public partial class LevelTransitionListenerComponent : TransitionListenerComponent
{
    [Export] private PackedScene scene_;

    public override void _Ready()
    {
        Node2D node_2d = scene_.Instantiate<Node2D>();
        if (node_2d == null) return;

        transision_timer_.Ended += ()=>
        {
            EventsQueue.instance.Publish(new EventLevelLoadRequest(node_2d));
        };
    }


}
