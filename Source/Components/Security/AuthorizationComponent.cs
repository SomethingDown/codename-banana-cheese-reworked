using Godot;
using Godot.Collections;

[GlobalClass]
public partial class AuthorizationComponent : Node
{
    [Export] public Array<AuthorizationResource> authorizations = new Array<AuthorizationResource>();


}
