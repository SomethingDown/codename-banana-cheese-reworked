using Godot;
using System;

[GlobalClass]
public partial class BreachableComponent : Node
{
    
    [Signal] public delegate void BreachedEventHandler();
    private bool breached_ = false;
    public bool IsBreached => breached_;
    public void Breach()
    {
        if (breached_ == true) return;
        breached_ = true;
        EmitSignal(SignalName.Breached);
    }

}
