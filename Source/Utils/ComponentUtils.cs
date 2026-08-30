using System.Collections.Generic;
using System.Linq;
using Godot;

public static class ComponentUtils
{
    public static T GetComponent<T>(this Node component) where T : class
    {
        var siblings = component.GetParent().GetChildren().ToList();
        foreach(var sibling in siblings)
            if (sibling is T t) return t;
        return null;
    }
    public static T GetComponentInEntity<T>(this Node entity) where T : class
    {
        var components = entity.GetChildren().ToList();
        foreach(var component in components)
            if (component is T t) return t;
        return null;
    }
    public static Node GetEntity(this Node component)
    {
        return component.GetParent();
    }
    public static T AddComponentInEntity<T>(this Node entity) where T : Node , new()
    {
        T t = new T();
        entity.AddChild(t);
        return t;
    }
    public static T AddComponent<T>(this Node component) where T : Node , new()
    {
        T t = new T();
        component.GetParent().AddChild(t);
        return t;
    }
}