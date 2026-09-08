using System.Collections.Generic;


public enum HeistEndState{Fail,Success};

public record EventHeistAddRequest : Event
{
    public HeistResource heist { get; private set; }
    public EventHeistAddRequest(HeistResource heist) { this.heist = heist; }
}

public record EventHeistUnlockRequest : Event
{
    public HeistResource heist { get; private set; }
    public EventHeistUnlockRequest(HeistResource heist) { this.heist = heist; }
}

public record EventHeistSelectRequest : Event
{
    public HeistResource heist { get; private set; }
    public EventHeistSelectRequest(HeistResource heist) { this.heist = heist; }
}

public record EventHeistsChanged : Event
{
    public List<HeistResource> heists { get; private set; }
    public EventHeistsChanged(List<HeistResource> heists) { this.heists = heists; }
}

public record EventHeistsUnlocked : Event
{
    public List<HeistResource> unlocked_heists { get; private set; }
    public EventHeistsUnlocked(List<HeistResource> unlocked_heists) { this.unlocked_heists = unlocked_heists; }
}

public record EventHeistSelected : Event
{
    public HeistResource heist { get; private set; }
    public EventHeistSelected(HeistResource heist) { this.heist = heist; }
}

public record EventHeistLaunchRequested : Event
{
    public HeistResource heist { get; private set; }
    public InventoryComponent transfer_inventory { get; private set; }

    public EventHeistLaunchRequested(HeistResource heist, InventoryComponent transfer_inventory)
    {
        this.heist = heist;
        this.transfer_inventory = transfer_inventory;
    }
    
}

public record EventHeistEndRequested : Event
{
    public HeistEndState state;
    public EventHeistEndRequested(HeistEndState state)
    {
        this.state = state;
    }
    
}

public record EventHeistLaunched : Event
{
    public HeistResource heist { get; private set; }

    public EventHeistLaunched(HeistResource heist )
    {
        this.heist = heist;
    }
    
}

public record EventHeistEnded : Event
{
    public HeistEndState state;
    public EventHeistEnded(HeistEndState state)
    {
        this.state = state;
    }
}

public record EventHeistResults : Event
{
    public HeistResultResource heist_results;

    public EventHeistResults(HeistResultResource heist_results)
    {
        this.heist_results = heist_results;
    }
}