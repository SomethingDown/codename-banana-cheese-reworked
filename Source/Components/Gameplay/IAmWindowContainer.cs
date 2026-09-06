using Godot;
using System;

[GlobalClass]
public partial class IAmWindowContainer : Node
{
    public override void _EnterTree()
    {
        CanvasLayer entity = this.GetEntity() as CanvasLayer;
        if (entity == null) return;
        WindowManager.instance.SubscribeWindowContainer(entity);
    }

    public override void _ExitTree()
    {
        WindowManager.instance.UnsubscribeWindowContainer();
    }
}
