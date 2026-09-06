using Godot;
using System;

[GlobalClass]
public partial class RestartSceneInteractionListenerComponent : InteractionListenerComponent
{
    public override void OnInteractionInitiated(Node entity)
    {
        GetTree().ReloadCurrentScene();
    }

}
