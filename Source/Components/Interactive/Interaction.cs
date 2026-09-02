using Godot;
using Godot.Collections;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__push_button_node.svg")]
public partial class Interaction : Node
{
    [Signal] public delegate void InteractionInitiatedEventHandler(Node interactor);
    [Signal] public delegate void InteractionCanceledEventHandler(Node interactor);

    [Export] public string label;
    [Export] public Array<AuthorizationResource> authorizations = new Array<AuthorizationResource>();
    
    public void Enter(Node interactor)
    {
        EmitSignal(SignalName.InteractionInitiated,interactor);
    }
    public void Exit(Node interactor)
    {
        EmitSignal(SignalName.InteractionCanceled,interactor);
    }
}
