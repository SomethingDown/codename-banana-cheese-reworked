using Godot;
using System;

[GlobalClass]
public partial class CenterPivotButtonUI : Button
{
    public override void _Ready()
    {
        Resized += ()=>{PivotOffset = Size/2;};
    }

}
