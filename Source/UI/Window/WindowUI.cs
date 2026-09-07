using Godot;
using System;
using System.Linq;
using System.Runtime.Serialization;

public partial class WindowUI : Control
{
    [Export] private Control panel_;
    [Export] public Node content
    {
        get => panel_.GetChildren().FirstOrDefault();
        set
        {
            panel_.GetChildren().ToList().ForEach(n=>n.QueueFree());
            if (panel_== null) return;
            panel_.AddChild(value);
        }
    }
    [Export] private LabelOptionUI exit_option_;


    public override void _EnterTree()
    {
        GetTree().Paused = false;

        if (exit_option_ == null) return;

        exit_option_.Pressed += OnExitButtonPressed;
    }

    public override void _ExitTree()
    {
        GetTree().Paused = false;

        if (exit_option_ == null) return;
        
        exit_option_.Pressed -= OnExitButtonPressed;
    }

    public void OnExitButtonPressed()
    {
        EventsQueue.instance.Publish(new EventWindowUnloadRequest());
    }


}
