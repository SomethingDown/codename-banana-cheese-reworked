using Godot;
using System;

[GlobalClass]
public partial class WindowTransitionListenerComponent : TransitionListenerComponent
{
    [Export] private PackedScene scene_;
    public override void _Ready()
    {
        if (scene_ == null) return;

        Control window = scene_.Instantiate<Control>();
        if (window == null) return;

        transision_timer_.Ended += ()=>
        {
            EventsQueue.instance.Publish(new EventWindowLoadRequest(window));
        };
    }


}
