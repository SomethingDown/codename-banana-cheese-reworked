using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class TextureOptionUI : HBoxContainer
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
    [Export] public Texture2D texture_2d
    {
        get
        {
            if(texture_ == null) return null;
            return texture_.Texture;
        }
        set
        {
            if(texture_ == null) return;
            texture_.Texture = value;
        }
    }
    [Export] private bool is_texture_visible_
    {
        get
        {
            if (texture_ == null) return false;
            return texture_.Visible;
        }
        set
        {
            if (texture_ == null) return;
            texture_.Visible = value;
        }
    }

    [Export] private Button button_;
    [Export] private TextureRect texture_;


    public override void _Ready()
    {
        if (button_ == null) return;
        button_.Pressed += ()=> EmitSignal(SignalName.Pressed);
    }



}
