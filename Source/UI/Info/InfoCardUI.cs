using Godot;
using System;

public partial class InfoCardUI : VBoxContainer
{
    [Export] public string title
    {
        get => label_title_?.Text ?? "";
        set
        {
            if (label_title_ == null) return;
            label_title_.Text = value;
        }
    }

    [Export] public string data
    {
        get => label_data_?.Text ?? "";
        set
        {
            if (label_data_ == null) return;
            label_data_.Text = value;
        }
    }

    [Export] private RichTextLabel label_title_;
    [Export] private RichTextLabel label_data_;
}