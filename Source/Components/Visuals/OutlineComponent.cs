using Godot;
using System;

[GlobalClass]
public partial class OutlineComponent : Node
{
    [Export] private CanvasItem visual_;
    [Export] private Vector2 partitions_in_visual_ = new Vector2(16.0f,16.0f);
    private ShaderMaterial outlineMaterial_;

    private Tween tween_;

    public override void _Ready()
    {
        outlineMaterial_ = new ShaderMaterial();
        outlineMaterial_.Shader = GD.Load<Shader>("res://Assets/Shaders/outline.gdshader");
        outlineMaterial_.SetShaderParameter("number_of_images",partitions_in_visual_);
    }


    public void EnableOutline()
    {
        outlineMaterial_.SetShaderParameter("outline_width",0.0f);
        visual_.Material = outlineMaterial_;
    }

    public void DisableOutline()
    {
        visual_.Material = null;
    }
}
