using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__push_button_node.svg")]
public partial class InteractableComponent : Node
{
    [Signal] public delegate void SelectedEventHandler();
    
    [Signal] public delegate void UnselectedEventHandler();
    
    public List<Interaction> interactions;
    public override void _Ready()
    {
       interactions = GetChildren().OfType<Interaction>().ToList();
    }

    public void Select()
    {
        GD.Print("fdsfg");
        EmitSignal(SignalName.Selected);
    }

    public void Unselect()
    {
        EmitSignal(SignalName.Unselected);
    }


}
