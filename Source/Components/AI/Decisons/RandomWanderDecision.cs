using Godot;
using System;

[GlobalClass]
public partial class RandomWanderDecision : Decision
{

    private Node2D entity_;
    private NavigationAgentComponent navigation_agent_;
    [Export] public float max_distance = 60.0f;

    private Random random_ = new Random();

    public override void _Ready()
    {
        base._Ready();
        entity_ = (Node2D)GetParent().GetEntity();
        navigation_agent_ = GetParent().GetComponent<NavigationAgentComponent>();
    }


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
        if (entity_ ==  null || navigation_agent_ == null ) return;
        
        if (intents_component.target_position == null)
        {
            intents_component.target_position = 
                entity_.GlobalPosition + 
                new Vector2(
                    (random_.NextSingle()*2 - 1) * max_distance,
                    (random_.NextSingle()*2 - 1) * max_distance
                );
        }
        
        if (navigation_agent_.IsTargetReached() || !navigation_agent_.IsTargetReachable())
        {
            intents_component.target_position = null;
        }

    }


}
