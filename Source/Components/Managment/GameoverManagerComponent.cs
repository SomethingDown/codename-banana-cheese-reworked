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

            GD.Print(e.entity_id," ",e.killer_id);

            // if (e.) 
            //     EventsQueue.instance.Publish(new EventLevelContainerRequest(scene_.Instantiate<Node2D>()));

        };
        EventsBus.instance.Subscribe(action);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(action);
    }


}
