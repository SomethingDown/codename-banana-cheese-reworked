using Godot;
using System;

public partial class CurrencyHud : Control
{
    [Export] private RichTextLabel currency_amount_label_;

    private CurrencyComponent currency_component_;

    public override void _Ready()
    {
        if (currency_amount_label_ != null) currency_amount_label_.Visible = false;
        EventsBus.instance.Subscribe(OnEvent);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
        UnsubscribeCurrency();
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventPlayerChanged e_p:
                OnPlayerChanged(e_p.entity);
                break;
            default:
                break;
        }
    }

    public void OnPlayerChanged(Node player)
    {
        UnsubscribeCurrency();

        currency_amount_label_.Visible = false;

        if (player == null || !GodotObject.IsInstanceValid(player)) return;

        currency_component_ = player.GetComponentInEntity<CurrencyComponent>();
        if (currency_component_ == null) return;

        currency_amount_label_.Visible = true;

        currency_component_.CurrencyChanged += OnSelectionChanged;
        OnSelectionChanged(currency_component_.GetCurrency());
    }

    private void UnsubscribeCurrency()
    {
        if (currency_component_ != null)
            currency_component_.CurrencyChanged -= OnSelectionChanged;
        currency_component_ = null;
    }

    public void OnSelectionChanged(float v)
    {
        currency_amount_label_.Text = $"{v}$";
    }
}