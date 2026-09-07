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
    public string name { get; private set; }

    public EventEntityDead(string name)
    {
        this.name = name;
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

    public EventWindowLoadRequest(Control content)
    {
        this.content = content;
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