using Godot;
using System;

[GlobalClass]
public partial class InstanceSceneInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_;
    [Export] private Node destination_;
    public override void OnInteractionInitiated(Node entity)
    {
        if (destination_ == null) return;
        if (scene_ == null) return;

        var scene_f = scene_.Instantiate();
        destination_.AddChild(scene_f);
    }

}
