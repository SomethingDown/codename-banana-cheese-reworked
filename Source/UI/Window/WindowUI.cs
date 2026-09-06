using Godot;
using System;
using System.Linq;

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

    public override void _EnterTree()
    {
        GetTree().Paused = false;
    }

    public override void _ExitTree()
    {
        GetTree().Paused = false;
    }


}
