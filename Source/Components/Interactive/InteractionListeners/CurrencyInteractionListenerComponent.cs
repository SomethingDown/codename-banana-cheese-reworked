using Godot;

[GlobalClass]
public partial class CurrencyInteractionListenerComponent : InteractionListenerComponent
{
    private bool collected = false;

    private CurrencyComponent currency_component_;
    private HackableComponent hackable_componnet_;

    public override void _Ready()
    {
        base._Ready();
        currency_component_ = this.GetComponent<CurrencyComponent>();
        hackable_componnet_ = this.GetComponent<HackableComponent>();
    }


    public override void OnInteractionInitiated(Node entity)
    {
        if (currency_component_ == null) return;
        if (currency_component_.GetCurrency() <= 0) return;

        HackableComponent hackable = this.GetComponent<HackableComponent>();
        if (hackable != null && !hackable.IsHacked) return;

        BreachableComponent breachable = this.GetComponent<BreachableComponent>();
        if (breachable != null && !breachable.IsBreached) return;

        entity.GetComponentInEntity<CurrencyComponent>()?.AddCurrency(currency_component_.SpendAllCurrency());
    }

}
