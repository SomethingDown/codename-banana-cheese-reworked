using Godot;
using System;

[GlobalClass]
public partial class SignalToOutlineComponent : Node
{
    
    [Export] private Node source_;
    [Export] private string enable_outline_signal_;
    [Export] private string disable_outline_signal_;

    
    private OutlineComponent outline_component_;
    

    public override void _Ready()
    {
        outline_component_ = this.GetComponent<OutlineComponent>();
        if (outline_component_ == null) return;

        source_.Connect(
            enable_outline_signal_,
            this.CreateCallableForSignal(source_,enable_outline_signal_,()=>outline_component_.EnableOutline())
        );
        source_.Connect(
            disable_outline_signal_,
            this.CreateCallableForSignal(source_,disable_outline_signal_,()=>outline_component_.DisableOutline())
        );
    }

    




}
