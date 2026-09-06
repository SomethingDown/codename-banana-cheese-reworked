using Godot;
using System;

[GlobalClass]
public partial class ChangeLevelInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_;
    public override void OnInteractionInitiated(Node entity)
    {
        if (scene_ == null) return;

        Node2D level_2d = scene_.Instantiate<Node2D>();
        if (level_2d == null) return;

        GameState.instance.LoadNewLevel(level_2d);
    }

}
