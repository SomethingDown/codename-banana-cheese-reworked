
public record EventObjectiveAdded: Event
{
    public ObjectiveResource objective;

    public EventObjectiveAdded(ObjectiveResource objective)
    {
        this.objective = objective;
    }
}

public record EventObjectiveUnlocked: Event
{
    public ObjectiveResource objective;

    public EventObjectiveUnlocked(ObjectiveResource objective)
    {
        this.objective = objective;
    }
}

public record EventObjectiveAquired: Event
{
    public ObjectiveResource objective;

    public EventObjectiveAquired(ObjectiveResource objective)
    {
        this.objective = objective;
    }
}

public record EventObjectiveSecureRequest: Event
{
    public ObjectiveResource objective;

    public EventObjectiveSecureRequest(ObjectiveResource objective)
    {
        this.objective = objective;
    }
}

public record EventObjectiveSecured: Event
{
    public ObjectiveResource objective;

    public EventObjectiveSecured(ObjectiveResource objective)
    {
        this.objective = objective;
    }
}

