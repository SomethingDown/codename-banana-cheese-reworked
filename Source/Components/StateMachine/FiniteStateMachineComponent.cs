using Godot;
using System;

[GlobalClass]
public partial class FiniteStateMachineComponent : Node
{

    [Export] public State initial_state;

    private State state_ = null;

    public override void _Ready()
    {
        state_ = initial_state;
        state_?.Enter();
    }


    public override void _Process(double delta)
    {
        if (state_ == null) return;

        State next_state = state_.Update();

        if (next_state == null) return;

        state_.Exit();
        state_ = next_state;
        state_.Enter();
    }


}
