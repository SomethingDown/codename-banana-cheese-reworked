using Godot;
using System;

public partial class ProxyDraw2D : Node2D
{
    public Action draw_handler = ()=>{};


    public override void _Draw()
    {
        draw_handler.Invoke();
    }

    public override void _PhysicsProcess(double delta)
    {
        QueueRedraw();
    }



}
