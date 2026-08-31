using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__signal_wave_custom_b3b3b3.svg")]
public partial class InteractionListenerComponent : Node
{
    [Export] public Interaction interaction;


    public override void _Ready()
    {
        interaction.InteractionInitiated += OnInteractionInitiated;
        interaction.InteractionCanceled += OnInteractionCanceled;
    }

    public virtual void OnInteractionInitiated(Node entity)
    {
        
    }

    public virtual void OnInteractionCanceled(Node entity)
    {
        
    }
}
