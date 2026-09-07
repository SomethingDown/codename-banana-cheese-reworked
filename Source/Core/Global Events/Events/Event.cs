using System;
using System.Collections.Generic;
using Godot;

public record Event
{
    public DateTime date_time { get; private set; }

    protected Event()
    {
        date_time = DateTime.Now;
    }
}

public record EventMessage : Event
{
    public string message;
}

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

public record EventWindowLoadRequest : Event
{
    public Control content { get; private set; }
    public bool is_exit_button_hidden {get; private set;} = true;

    public EventWindowLoadRequest(Control content)
    {
        this.content = content;
    }
    public EventWindowLoadRequest(Control content,bool is_exit_button_hidden)
    {
        this.content = content;
        this.is_exit_button_hidden = is_exit_button_hidden;
    }
}

public record EventWindowUnloadRequest : Event
{
}

public record EventWindowChanged : Event
{
    public Control content { get; private set; }

    public EventWindowChanged(Control content)
    {
        this.content = content;
    }
}

public record EventWindowContainerRequest : Event
{
    public CanvasLayer window_container { get; private set; }

    public EventWindowContainerRequest(CanvasLayer window_container)
    {
        this.window_container = window_container;
    }
}

public record EventWindowContainerChanged : Event
{
    public CanvasLayer window_container { get; private set; }

    public EventWindowContainerChanged(CanvasLayer window_container)
    {
        this.window_container = window_container;
    }
}

public record EventLevelLoadRequest : Event
{
    public Node2D level {get; private set;}

    public EventLevelLoadRequest(Node2D level)
    {
        this.level = level;
    }
}

public record EventLevelUnloadRequest : Event
{

}

public record EventLevelChanged : Event
{
    public Node2D level {get; private set;}

    public EventLevelChanged(Node2D level)
    {
        this.level = level;
    }
}

public record EventLevelContainerRequest : Event
{
    public Node2D level_container {get; private set;}

    public EventLevelContainerRequest(Node2D level_container)
    {
        this.level_container = level_container;
    }
}

public record EventLevelContainerChanged : Event
{
    public Node2D level_container {get; private set;}

    public EventLevelContainerChanged(Node2D level_container)
    {
        this.level_container = level_container;
    }
}

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

public record EventPlayerSubscribeRequest : Event
{
    public Node entity { get; private set; }
    public EventPlayerSubscribeRequest(Node entity) { this.entity = entity; }
}

public record EventPlayerUnsubscribeRequest : Event { }

public record EventPlayerChanged : Event
{
    public Node entity { get; private set; }
    public EventPlayerChanged(Node entity) { this.entity = entity; }
}

public record EventGameover : Event
{
    public HeistResultResource heist_result {get; private set;}
    public EventGameover(HeistResultResource heist_result) { this.heist_result = heist_result; }
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

public enum HeistEndState{Fail,Success};

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
