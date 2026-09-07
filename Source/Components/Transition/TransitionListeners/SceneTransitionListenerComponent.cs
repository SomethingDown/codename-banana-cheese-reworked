using Godot;
using System;

[GlobalClass]
public partial class SceneTransitionListenerComponent : Node
{
    [Export] private PackedScene scene_;
    [Export] private TransitionTimerComponent transision_timer_;

    public override void _Ready()
    {
        transision_timer_.Ended += ()=>
        {
            Node2D node_2d = scene_.Instantiate<Node2D>();
            if (node_2d == null) return;
            EventsQueue.instance.Publish(new EventLevelLoadRequest(node_2d));
        };
    }


}
