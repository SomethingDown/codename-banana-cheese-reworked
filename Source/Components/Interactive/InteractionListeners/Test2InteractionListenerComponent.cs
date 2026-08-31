using Godot;
using System;

[GlobalClass]
public partial class Test2InteractionListenerComponent : InteractionListenerComponent
{

    public override void OnInteractionInitiated(Node entity)
    {
        entity.GetComponentInEntity<CharacterMovementComponent>().enabled = true;
    }


}
