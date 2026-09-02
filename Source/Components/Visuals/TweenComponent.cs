using Godot;
using Godot.Collections;
using System;
using System.Linq;

[GlobalClass]
public partial class TweenComponent : Node
{
    public void InitiateTween(Array<TweenResource> res_array)
    {
        Tween tween = CreateTween();
        res_array.ToList().ForEach(r =>
        {
            Node node = this.GetEntity().GetNode(r.node_path);
            if (node == null) return;

            if (r.parallel_to_previous) tween.SetParallel(true);
            else tween.SetParallel(false);
            tween.TweenProperty(node,r.action,r.value,r.duration);            
        });
    }
}
