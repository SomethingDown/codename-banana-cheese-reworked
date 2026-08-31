using Godot;
using System;

[GlobalClass]
public partial class CurrencyInteractionListenerComponent : InteractionListenerComponent
{
    [Export] public float currency = 100.0f;
    private bool collected = false;
    public override void OnInteractionInitiated(Node entity)
    {
        if (collected == true) return;
        entity.GetComponentInEntity<CurrencyComponent>()?.AddCurrency(currency);
        collected = true;
    }

}
