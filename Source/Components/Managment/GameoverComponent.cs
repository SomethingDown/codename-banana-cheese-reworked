using Godot;
using System;

[GlobalClass]
public partial class GameoverComponent : Node
{
    [Export] private PackedScene scene_;
    private Action<Event> action = null;
    public override void _Ready()
    {
        action =  _ =>
        {
            EventEntityDead e = _ as EventEntityDead;
            if (e == null) return;

            if (e.name.Equals("Player")) GameState.instance.LoadNewLevel(scene_.InstantiateOrNull<Node2D>());        

        };
        EventsBus.instance.Subscribe(action);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(action);
    }


}
