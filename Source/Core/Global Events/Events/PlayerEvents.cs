
using Godot;

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
