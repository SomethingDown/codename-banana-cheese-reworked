using Godot;
using System;

[GlobalClass]
public partial class HeistSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(HeistResource res);
    public HeistResource selected_heist {get;private set;}

    public void select(HeistResource heist_resource)
    {
        if (heist_resource == selected_heist) return;
        selected_heist = heist_resource;
        EmitSignal(SignalName.SelectionChanged,heist_resource);
    }
}
