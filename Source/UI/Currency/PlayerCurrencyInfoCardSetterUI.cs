using Godot;
using System;

[GlobalClass]
public partial class PlayerCurrencyInfoCardSetterUI : Node
{
    [Export] private InfoCardUI infocard_;

    public override void _Ready()
    {
        if (infocard_ == null) return;

        infocard_.title = "Currency";
        infocard_.data = $"{PlayerState.instance.banked_currency_component.GetCurrency()}$";
        PlayerState.instance.banked_currency_component.CurrencyChanged += v =>
        {
            infocard_.data = $"{v}$";
        };
    }


}
