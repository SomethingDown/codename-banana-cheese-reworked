using Godot;
using System;

[GlobalClass]
public partial class RestartGameInteractionListenerComponent : InteractionListenerComponent
{
    public override void OnInteractionInitiated(Node entity)
    {
        GetTree().ReloadCurrentScene();
    }

}
