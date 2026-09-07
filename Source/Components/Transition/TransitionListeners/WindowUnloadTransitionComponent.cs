using Godot;
using System;

[GlobalClass]
public partial class WindowUnloadTransitionComponent : TransitionListenerComponent
{
    public override void _Ready()
    {
        transision_timer_.Ended += ()=>
        {
            EventsQueue.instance.Publish(new EventWindowUnloadRequest());
        };
    }
}
