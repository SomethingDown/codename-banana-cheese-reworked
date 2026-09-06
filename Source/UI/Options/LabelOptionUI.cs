using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class LabelOptionUI : HBoxContainer
{
    [Signal] public delegate void PressedEventHandler();
    [Export] public string button_text
    {
        get
        {
            if(button_ == null) return "";
            return button_.Text;
        }
        set
        {
            if(button_ == null) return;
            button_.Text = value;
        }
    }
    [Export] public string label_text
    {
        get
        {
            if(label_ == null) return "";
            return label_.Text;
        }
        set
        {
            if(label_ == null) return;
            label_.Text = value;
        }
    }
    [Export] private Button button_;
    [Export] private RichTextLabel label_;
    [Export] private bool is_label_invisible_
    {
        get => label_?.Visible ?? false;
        set
        {
            GD.Print($"Setter called, value={value}, label_ is null={label_ == null}");
            if (label_ == null) return;
            label_.Visible = !value;
        }
    }

    public override void _Ready()
    {
        if (button_ == null) return;
        button_.Pressed += ()=> EmitSignal(SignalName.Pressed);
    }



}
