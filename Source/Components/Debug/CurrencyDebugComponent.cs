using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__speech_bubble_exclamation_node.svg")]
public partial class CurrencyDebugComponent : Node
{
    private CurrencyComponent currency_component_;


    public override void _Ready()
    {
        currency_component_ = this.GetComponent<CurrencyComponent>();
    }

    public override void _Process(double delta)
    {
        EventsQueue.instance.Publish(new EventMessage{message=$"Currency: {currency_component_.GetCurrency()}"});
    }




}
