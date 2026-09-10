using Godot;
using System;

public partial class HintsHud : Control
{
    Tween tween;

    public override void _Ready()
    {
        Modulate = Colors.Transparent;
        EventsBus.instance.Subscribe(OnEvent);
    }
    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }

    public void OnEvent(Event e)
    {
        if (e is EventPlayerChanged _e)
        {
            if (_e.entity == null) return;

            PopAndFade();
        }
    }



    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey key_event && key_event.Pressed && !key_event.Echo)
        {
            if (key_event.Keycode == Key.H)
            {
                PopAndFade();
            }
        }
    }

    private void PopAndFade()
    {
        tween?.Kill();
        tween = CreateTween();
        tween.TweenProperty(this,"modulate:a",1.0f,0.4);
        tween.TweenInterval(5);
        tween.TweenProperty(this,"modulate:a",0.0f,0.4);
    }

}
