using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class WindowManagerComponent : Node
{
    private PackedScene windowui_scene_ = GD.Load<PackedScene>("res://Scenes/UI/Window/Window.tscn");
    private CanvasLayer window_container;
    private WindowUI windowui_;

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
        if (e is EventWindowLoadRequest window_load_event)
        {
            LoadNewWindow(window_load_event.content,window_load_event.is_exit_button_hidden);
        }
        else if (e is EventWindowUnloadRequest window_unload_event)
        {
            UnloadWindow();
        }
        else if (e is EventWindowContainerRequest window_container_load_event)
        {
            SetWindowContainer(window_container_load_event.window_container);
        }
        
    }


    private void LoadNewWindow(Control window,bool is_exit_button_hidden)
    {
        windowui_ = windowui_scene_.Instantiate<WindowUI>();

        if (window == null || windowui_ == null) return;
        UnloadWindow();
        window_container?.AddChild(windowui_);
        windowui_.is_exit_option_hidden = is_exit_button_hidden;
        windowui_.content = window;
        EventsQueue.instance.Publish(new EventWindowChanged(window));

    }

    private void UnloadWindow()
    {
        window_container?.GetChildren().ToList().ForEach(l=>{if(l is not IAmWindowContainer)if(!l.IsQueuedForDeletion())l.QueueFree();});
        EventsQueue.instance.Publish(new EventWindowChanged(null));
    }

    private void SetWindowContainer(CanvasLayer canvas)
    {
        window_container = canvas;
        EventsQueue.instance.Publish(new EventWindowContainerChanged(canvas));

    }
}
