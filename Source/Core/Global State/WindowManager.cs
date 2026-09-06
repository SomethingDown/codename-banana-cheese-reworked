using Godot;
using System;
using System.Linq;

public class WindowManager
{
    static private WindowManager instance_ = new WindowManager();
    static public WindowManager instance => instance_;

    public CanvasLayer window_container;
    public Action<Control> WindowChanged;

    private PackedScene windowui_scene_ = GD.Load<PackedScene>("res://Scenes/UI/Window/Window.tscn");
    private WindowUI windowui_;

    public void LoadNewWindow(Control window)
    {
        GD.Print(window_container);
        if (window == null || windowui_ == null) return;

        window_container?.GetChildren().ToList().ForEach(l=>{if(l is not IAmWindowContainer)window_container.RemoveChild(l);});
        window_container?.AddChild(windowui_);
        windowui_.content = window;
        WindowChanged?.Invoke(window);
    }
    
    public void SubscribeWindowContainer(CanvasLayer canvas_layer)
    {
        windowui_ = windowui_scene_.Instantiate<WindowUI>();
        if (windowui_ == null) return;

        if (canvas_layer == null) return;
        window_container = canvas_layer;
        WindowChanged?.Invoke(null);
    }

    public void UnsubscribeWindowContainer()
    {
        window_container = null;
    }

}
