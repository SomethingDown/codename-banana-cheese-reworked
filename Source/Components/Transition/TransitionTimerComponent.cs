using Godot;
using System;
using System.Diagnostics.Contracts;

[GlobalClass]
public partial class TransitionTimerComponent : Node
{
    [Signal] public delegate void StartedEventHandler();
    [Signal] public delegate void EndedEventHandler();

    [Export] private Node source_;
    [Export] private string signal_name_; 
    [Export] private float time_=1.0f;


    public override void _Ready()
    {
        if(source_ == null) return;

        source_.Connect(
            signal_name_,
            this.CreateCallableForSignal(source_,signal_name_,()=>
                {
                    EmitSignal(SignalName.Started);
                    Tween tween = CreateTween();
                    tween.TweenInterval(time_);
                    tween.Finished += ()=>{EmitSignal(SignalName.Ended);};
                })
        );
    }
}
