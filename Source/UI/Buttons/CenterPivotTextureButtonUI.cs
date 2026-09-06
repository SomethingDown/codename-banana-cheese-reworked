using Godot;
using System;

[GlobalClass]
public partial class CenterPivotTextureButtonUI : TextureButton
{
    public override void _Ready()
    {
        Resized += ()=>{PivotOffset = Size/2;};
    }

}
