


using Godot;

public record EventNotificationTransmitted : Event
{
    public NotificationResource notification;
    public EventNotificationTransmitted(NotificationResource notification)
    {
        this.notification = notification;
    }
}

public record EventNotificationHandleRequest : Event
{
    public NotificationResource notification;
    public EventNotificationHandleRequest(NotificationResource notification)
    {
        this.notification = notification;
    }
}

public record EventNotificationHandled : Event
{
    public NotificationResource notification;
    public EventNotificationHandled(NotificationResource notification)
    {
        this.notification = notification;
    }
}

