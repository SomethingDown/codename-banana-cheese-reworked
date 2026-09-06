using Godot;
using System;

[GlobalClass]
public partial class SceneTransitionListenerComponent : Node
{
    [Export] private PackedScene scene_;
    [Export] private TransitionTimerComponent transision_timer_;

    public override void _Ready()
    {
        transision_timer_.Ended += ()=>
        {
            Node2D scene = scene_.Instantiate<Node2D>();
            if (scene == null) return;
            GameState.instance.LoadNewLevel(scene);
        };
    }


}
