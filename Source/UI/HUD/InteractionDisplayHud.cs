using Godot;
using System;

public partial class InteractionDisplayHud : Control
{
    [Export] private RichTextLabel interaction_name_label;

    public string interaction_name
    {
        get=> interaction_name_label.Text;
        set => interaction_name_label.Text = value;
    }

}
