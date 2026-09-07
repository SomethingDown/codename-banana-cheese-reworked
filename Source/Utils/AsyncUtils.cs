using System;
using Godot;

public static class AsyncUtils
{
    public static void InvokeNextFrame(Action action)
    {
        SceneTree tree = (SceneTree)Engine.GetMainLoop();
        if (tree == null) return;
        
        Action handle = null;
        handle = () =>
        {
            action.Invoke();
            tree.ProcessFrame -= handle;
        };
        tree.ProcessFrame+= handle;
    }
}