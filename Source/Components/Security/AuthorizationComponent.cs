using Godot;
using Godot.Collections;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__warning_triangle_node.svg")]
public partial class AuthorizationComponent : Node
{
    [Export] public Array<AuthorizationResource> authorizations = new Array<AuthorizationResource>();


}
