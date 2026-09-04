using System;
using Godot;

public static class AsyncUtils
{
    public static void InvokeNextFrame(this Node node,Action action)
    {
        SceneTree tree = node.GetTree();
        if (tree == null) return;
        
        Action handle = null;
        handle = () =>
        {
            if (!GodotObject.IsInstanceValid(node)) return;
            action.Invoke();
            tree.ProcessFrame -= handle;
        };
        tree.ProcessFrame+= handle;
    }
}