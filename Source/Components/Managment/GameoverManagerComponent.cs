using Godot;
using System;

[GlobalClass]
public partial class GameoverManagerComponent : Node
{
    [Export] private PackedScene scene_;
    private Action<Event> action = null;
    public override void _Ready()
    {
        action =  _ =>
        {
            EventEntityDead e = _ as EventEntityDead;
            if (e == null) return;

            if (e.name.Equals("Player")) 
                EventsQueue.instance.Publish(new EventLevelContainerRequest(scene_.Instantiate<Node2D>()));

        };
        EventsBus.instance.Subscribe(action);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(action);
    }


}
