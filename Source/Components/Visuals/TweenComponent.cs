using Godot;
using Godot.Collections;
using System;
using System.Linq;

[GlobalClass]
public partial class TweenComponent : Node
{
        Tween tween;

    public void InitiateTween(Array<TweenResource> res_array)
    {
        tween =  CreateTween();
        int count = 0;
        res_array.ToList().ForEach(r =>
        {
            Node node = GetNodeOrNull(r.node_path);
            if (node == null) return;

            if (r.parallel_to_previous) tween.SetParallel(true);
            else tween.SetParallel(false);
            tween.TweenProperty(node,r.action,r.value,r.duration);
            count++;  
        });
        if (count == 0) tween.Kill();
    }
}
