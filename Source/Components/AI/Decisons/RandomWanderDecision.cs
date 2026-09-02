using Godot;
using System;

[GlobalClass]
public partial class RandomWanderDecision : Decision
{

    [Export] public float max_distance = 60.0f;
    private Node2D entity_;
    private CharacterStuckNotifierComponnet stuck_notifier_;
    private Random random_ = new Random();

    public override void _Ready()
    {
        base._Ready();
        entity_ = (Node2D)GetParent().GetEntity();
        stuck_notifier_ = GetParent().GetComponent<CharacterStuckNotifierComponnet>();
        if (stuck_notifier_!=null) stuck_notifier_.CharacterStuck += () =>
        {
            intents_component.target_position = null;
        };
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
        if (entity_ == null) return;
        if (intents_component.target_position == null)
        {
            float angle = random_.NextSingle() * Mathf.Tau;
            float dist = random_.NextSingle() * max_distance;
            intents_component.target_position = entity_.GlobalPosition + Vector2.Right.Rotated(angle) * dist;
        }
    }
}
