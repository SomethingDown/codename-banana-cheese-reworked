using Godot;
using System;

[GlobalClass]
public partial class Decision : Node
{
    [Export] public ActorIntentsComponent intents_component;
    [Export] public float success_score;

    public virtual void Enter(){}
    public virtual void Exit(){}
    public virtual float GetScore(){return success_score;}
    public virtual void Execute(){if (intents_component==null) return;}
}
