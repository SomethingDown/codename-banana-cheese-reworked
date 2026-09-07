using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class InstanceWindowedSceneInteractionListenerComponent : InteractionListenerComponent
{
    [Export] private PackedScene scene_scene_;
    [Export] private bool is_exit_button_hidden;


    public override void _Ready()
    {
        base._Ready();
    }

    public override void OnInteractionInitiated(Node entity)
    {
        Control window = scene_scene_.Instantiate<Control>();

        if (window == null) return;

        EventsQueue.instance.Publish(new EventWindowLoadRequest(window,is_exit_button_hidden));
    }



}
