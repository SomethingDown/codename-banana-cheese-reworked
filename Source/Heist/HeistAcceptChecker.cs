using Godot;
using System;

[GlobalClass]
public partial class HeistAcceptChecker : Node
{
    [Signal] public delegate void HeistRequestAcceptedEventHandler();
    [Signal] public delegate void HeistRequestUnacceptedEventHandler();

    [Export] private DisplayableResourcesSelectorComponent heist_selector_;
    [Export] private LabelOptionUI option_;
    public override void _Ready()
    {
        if (heist_selector_ == null) return;
        if (option_ == null) return;

        option_.Pressed += () =>
        {
            HeistResource heist_resource = heist_selector_.selected_resource as HeistResource;
            if (heist_resource == null)
            {
                EmitSignal(SignalName.HeistRequestUnaccepted);
                return;
            }
            EmitSignal(SignalName.HeistRequestAccepted);
        };
    }

}
