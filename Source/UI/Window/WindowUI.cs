using Godot;
using System;
using System.Linq;
using System.Runtime.Serialization;

public partial class WindowUI : Control
{
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
    [Export] public bool is_exit_option_hidden
    {
        get => !exit_option_.Visible;
        set => exit_option_.Visible = !value;
    }
    
    [Export] private LabelOptionUI exit_option_;
    [Export] private Control panel_;


    public override void _EnterTree()
    {
        GetTree().Paused = true;

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
