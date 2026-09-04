using Godot;
using System;

[GlobalClass]
public partial class GameoverComponent : Node
{
        Action<Event> action = null;
    public override void _Ready()
    {
        action =  _ =>
        {
            EventEntityDead e = _ as EventEntityDead;
            if (e == null) return;

            if (e.name.Equals("Player")) GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);            

        };
        EventsBus.instance.Subscribe(action);
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(action);
    }


}
