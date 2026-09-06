using Godot;
using System;
using System.Linq;

public class GameState
{
    static private GameState instance_ = new GameState();
    static public GameState instance => instance_;

    public Node2D level_container;
    public Action<Node2D> LevelChanged;


    public void LoadNewLevel(Node2D level)
    {
        GD.Print(level_container);
        if (level == null) return;

        level_container?.GetChildren().ToList().ForEach(l=>{if(l is not IAmLevelContainer)l.QueueFree();});//Might cause issues so consider changingt to RemoveChild...
        level_container?.AddChild(level);
        LevelChanged?.Invoke(level);
    }
    
    public void SubscribeLevelContainer(Node2D node)
    {
        if (node == null) return;
        level_container = node;
        LevelChanged?.Invoke(null);
    }

    public void UnsubscribeLevelContainer()
    {
        level_container = null;
    }

}
