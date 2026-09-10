using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__workspace_desk_node.svg")]
public partial class NotificationManagerComponent : Node
{
    private Queue<NotificationResource> notifications_queue_ = new Queue<NotificationResource>();
    private bool busy = false;
    public override void _Ready()
    {
        EventsBus.instance.Subscribe(OnEvent);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventNotificationTransmitted _e:
                OnNotificationTransmitted(_e.notification);
                break;
            case EventNotificationHandled _e:
                OnNotificationHandled(_e.notification);
                break;
            default:
                break;
        }
    }

    public void OnNotificationTransmitted(NotificationResource notification)
    {
        notifications_queue_.Enqueue(notification);
        
        if (busy) return;
        EventsQueue.instance.Publish(new EventNotificationHandleRequest(notifications_queue_.Dequeue()));
        busy = true;
    }

    public void OnNotificationHandled(NotificationResource notification)
    {
        if (notifications_queue_.Count <= 0)
        {
            busy = false;
            return;
        }
        EventsQueue.instance.Publish(new EventNotificationHandleRequest(notifications_queue_.Dequeue()));
    }

}
