using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class LaunchLastHeistTransitionListenerComponent : TransitionListenerComponent
{
    
    public override void _Ready()
    {
        HeistResultResource last_heist_results = HeistState.instance.GetHeistLog().LastOrDefault();
        if (last_heist_results == null) return;

        transision_timer_.Ended += ()=>
        {
            EventsQueue.instance.Publish(new EventHeistLaunchRequested(last_heist_results.heist,last_heist_results.inventory_used));
        };
    }
}
