using Godot;
using System;

[GlobalClass]
public partial class TestInteractionListenerComponent : InteractionListenerComponent
{

    public override void OnInteractionInitiated(Node entity)
    {
        entity.GetComponentInEntity<CharacterMovementComponent>().enabled = false;
    }


}
