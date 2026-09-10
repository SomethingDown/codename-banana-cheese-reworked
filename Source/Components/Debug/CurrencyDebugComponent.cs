using Godot;
using System;
using System.Diagnostics;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class CurrencyDebugComponent : DebugComponent
{
    private CurrencyComponent currency_component_;


    public override void _Ready()
    {
        currency_component_ = this.GetComponent<CurrencyComponent>();
        currency_component_.CurrencyChanged += c =>
        {
            if (enabled)
            EventsQueue.instance.Publish(new EventMessage{message=$"Currency: {c}"});
        };
    }

    public override void _Process(double delta)
    {
        
    }




}
