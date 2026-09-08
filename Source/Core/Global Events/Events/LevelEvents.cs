


using Godot;

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