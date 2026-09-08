using Godot;
using System;
using System.Reflection.Emit;

public partial class NotificationRecieverUIComponent : Node
{
    [Signal] public delegate void NotificationReadyEventHandler();
    [Export] private Control notif_container;
    [Export] private InfoCardUI notif_info;
    [Export] private TextureRect notif_icon;

    [Export] private float pop_in_time = 0.4f;
    [Export] private float hold_time = 2.0f;
    [Export] private float pop_out_time = 0.8f;


    public override void _Ready()
    {
        if (notif_info == null) return;
        if (notif_icon == null) return;
        if (notif_container == null) return;

        notif_container.Visible = false;
        notif_container.Modulate = Colors.Transparent;

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
            case EventNotificationHandleRequest _e:
                OnNotificationHandleRequest(_e.notification);
                break;
            default:
                break;
        }


    }

    public void OnNotificationHandleRequest(NotificationResource notification)
    {
        if (notification == null) return;

        if (notification.icon == null) notif_icon.Visible = false;
        else notif_icon.Texture = notification.icon;

        notif_info.title = notification.title;
        notif_info.data = notification.data;

        EmitSignal(SignalName.NotificationReady);

        notif_container.Visible = true;

        Tween tween = CreateTween();
        tween.TweenProperty(notif_container,"modulate:a",1.0f,pop_in_time);
        tween.TweenInterval(hold_time);
        tween.TweenProperty(notif_container,"modulate:a",0.0f,pop_out_time);
        Action action = null;
        action = () =>
        {
            notif_container.Visible = false;
            EventsQueue.instance.Publish(new EventNotificationHandled(notification));
            tween.Finished -= action;
        };
        tween.Finished += action;
    }


}
