using Godot;
using System;

public partial class CurrencyHud : Control
{
    [Export] private RichTextLabel currency_amount_label_;

    public override void _Ready()
    {
        PlayerState.instance.PlayerChanged += OnPlayerChanged;
        OnPlayerChanged(PlayerState.instance.player_entity);

    }
    public override void _ExitTree()
    {
        PlayerState.instance.PlayerChanged -= OnPlayerChanged;
    }
    public void OnPlayerChanged(Node player)
    {
        currency_amount_label_.Visible = false;

        if (player == null) return;

        currency_amount_label_.Visible = true;

            CurrencyComponent currency_component = player.GetComponentInEntity<CurrencyComponent>();
            if(currency_component == null) return;

            currency_component.CurrencyChanged += OnSelectionChanged;
            OnSelectionChanged(currency_component.GetCurrency());
    }

    public void OnSelectionChanged(float v)
    {
        currency_amount_label_.Text = $"{v}$";
    }
}
