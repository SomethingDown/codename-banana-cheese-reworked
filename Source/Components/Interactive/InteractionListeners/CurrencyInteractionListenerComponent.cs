using Godot;

[GlobalClass]
public partial class CurrencyInteractionListenerComponent : InteractionListenerComponent
{
    [Signal] public delegate void CurrencyDepleatedEventHandler();
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
        if (hackable != null && !hackable.IsHacked)
        {
            EventsQueue.instance.Publish(new EventNotificationTransmitted(new NotificationResource{title="Warning",Description="Requires [wave]hacking!"}));
            return;
        }

        BreachableComponent breachable = this.GetComponent<BreachableComponent>();
        if (breachable != null && !breachable.IsBreached)
        {
            EventsQueue.instance.Publish(new EventNotificationTransmitted(new NotificationResource{title="Warning",Description="Requires [wave]breaching!"}));
            return;
        }

        entity.GetComponentInEntity<CurrencyComponent>()?.AddCurrency(currency_component_.SpendAllCurrency());
        EmitSignal(SignalName.CurrencyDepleated);
    }

}
