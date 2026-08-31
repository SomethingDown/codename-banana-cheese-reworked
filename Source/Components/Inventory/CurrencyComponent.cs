using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__coins_node.svg")]
public partial class CurrencyComponent : Node
{
    [Signal] public delegate void SpendFailedEventHandler(float value);
    [Signal] public delegate void CurrencyAddFailedEventHandler(float value);
    [Signal] public delegate void CurrencyChangedEventHandler(float value);

    private float currency_val_;

    private float currency_
    {
        get=>currency_val_;
        set
        {
            currency_val_=value;
            EmitSignal(SignalName.CurrencyChanged,currency_val_);
        }
    }


    public bool TrySpend(float value)
    {
        if (currency_ < value || value <= 0)
        {
            EmitSignal(SignalName.SpendFailed,value);
            return false;
        }
        currency_ -= value;
        return true;
    }

    public void AddCurrency(float value)
    {
        if (value <= 0)
        {
            EmitSignal(SignalName.CurrencyAddFailed,value);
            return;
        }
        currency_ += value;
    }

    public float GetCurrency()
    {
        return currency_;
    }

}
