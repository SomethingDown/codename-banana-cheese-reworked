using Godot;
using System;

[GlobalClass]
public partial class RandomWanderDecision : Decision
{

    [Export] public Node2D entity_;
    [Export] public NavigationAgentComponent navigation_agent;
    [Export] public float max_distance = 60.0f;

    private Random random_ = new Random();

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        intents_component.target_position = null;
    }

    public override void Execute()
    {
        base.Execute();
        if (entity_ ==  null || navigation_agent == null ) return;
        
        if (intents_component.target_position == null)
        {
            intents_component.target_position = 
                entity_.GlobalPosition + 
                new Vector2(
                    (random_.NextSingle()*2 - 1) * max_distance,
                    (random_.NextSingle()*2 - 1) * max_distance
                );
        }
        
        if (navigation_agent.IsTargetReached() || !navigation_agent.IsTargetReachable())
        {
            intents_component.target_position = null;
        }

    }


}
