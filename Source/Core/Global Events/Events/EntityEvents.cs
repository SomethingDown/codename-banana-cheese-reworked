

public record EventEntityDead : Event
{
    public ulong entity_id { get; private set; }
    public ulong killer_id { get; private set; }

    public EventEntityDead(ulong entity_id,ulong killer_id)
    {
        this.entity_id = entity_id;
        this.killer_id = killer_id;
    }
}

public record EventEntityCurrencyChanged : Event
{
    public ulong id { get; private set; }
    public float currency { get; private set; }

    public EventEntityCurrencyChanged(ulong id, float currency)
    {
        this.id = id;
        this.currency = currency;
    }
}

public record EventEntitySpawned : Event
{
    public string name { get; private set; }

    public EventEntitySpawned(string name)
    {
        this.name = name;
    }
}