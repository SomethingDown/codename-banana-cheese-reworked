using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class InstanceWindowedSceneInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_scene_;
    [Export] private PackedScene window_scene_;
    [Export] private Node destination_;

    private WindowUI window_;

    public override void _Ready()
    {
        base._Ready();
        window_ = window_scene_.Instantiate<WindowUI>();
    }

    public override void OnInteractionInitiated(Node entity)
    {
        if (destination_ == null) return;
        if (scene_scene_ == null) return;
        if (window_ == null) return;

        if (window_.GetParent() != null)
            window_.GetParent().RemoveChild(window_);

        destination_.AddChild(window_);

        window_.content = scene_scene_.Instantiate();
    }



}
