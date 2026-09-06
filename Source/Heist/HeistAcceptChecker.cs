using Godot;
using System;

[GlobalClass]
public partial class HeistAcceptChecker : Node
{
    [Signal] public delegate void HeistRequestCheckedEventHandler(bool state);
    [Export] private HeistSelectorComponent heist_selector_;
    [Export] private LabelOptionUI option_;
    public override void _Ready()
    {
        if (heist_selector_ == null) return;
        if (option_ == null) return;

        option_.Pressed += () =>
        {
            if (heist_selector_.selected_heist == null)
            {
                EmitSignal(SignalName.HeistRequestChecked,false);
                return;
            }
            EmitSignal(SignalName.HeistRequestChecked,true);
        };
    }

}
