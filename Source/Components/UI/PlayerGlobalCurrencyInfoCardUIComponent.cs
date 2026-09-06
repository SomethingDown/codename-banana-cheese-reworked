using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobalCurrencyInfoCardUIComponent : Node
{
    [Export] private InfoCardUI infocard_;

    public override void _Ready()
    {
        if (infocard_ == null) return;

        infocard_.title = "Currency";
        infocard_.data = $"{PlayerState.instance.banked_currency_component.GetCurrency()}$";
        PlayerState.instance.banked_currency_component.CurrencyChanged += OnBankedCurrencyChanged;
    }
    public override void _ExitTree()
    {
        PlayerState.instance.banked_currency_component.CurrencyChanged -= OnBankedCurrencyChanged;
    }

    public void OnBankedCurrencyChanged(float v)
    {
        infocard_.data = $"{v}$";
    }

    


}
