using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__push_button_node.svg")]
public partial class InteractableComponent : Node
{
    public List<Interaction> interactions;
    public override void _Ready()
    {
       interactions = GetChildren().OfType<Interaction>().ToList();
    }


}
