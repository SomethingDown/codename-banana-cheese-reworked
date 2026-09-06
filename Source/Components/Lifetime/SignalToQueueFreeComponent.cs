using Godot;
using System;

[GlobalClass]
public partial class SignalToQueueFreeComponent : Node
{
    [Export] private Node source_;
    [Export] private string signal_name_;
    [Export] private Node node_;

    public override void _Ready()
    {
        if (source_ == null) return;
        if (node_ == null) return;

        source_.Connect(signal_name_,
        this.CreateCallableForSignal(source_, signal_name_, () =>
        {
            node_.QueueFree();
        })
        );


    }


}
