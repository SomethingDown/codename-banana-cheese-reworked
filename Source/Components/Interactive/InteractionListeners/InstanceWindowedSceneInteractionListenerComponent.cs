using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class InstanceWindowedSceneInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_scene_;


    public override void _Ready()
    {
        base._Ready();
    }

    public override void OnInteractionInitiated(Node entity)
    {
        if (scene_scene_ == null) return;
        WindowManager.instance.LoadNewWindow(scene_scene_.Instantiate<Control>());
    }



}
