using Godot;
using System;

[GlobalClass]
public partial class HackableComponent : Node
{
    
    [Signal] public delegate void HackedEventHandler();
    private bool hacked_ = false;
    public bool IsHacked => hacked_;
    public void Hack()
    {
        if (hacked_ == true) return;
        hacked_ = true;
        EmitSignal(SignalName.Hacked);
    }

}
