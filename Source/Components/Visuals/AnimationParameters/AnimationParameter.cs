using Godot;
using System;

[GlobalClass]
public partial class AnimationParameter : Node
{
    [Export] public string parameter_name;
    public virtual Vector2 GetValue()
    {
        return Vector2.Zero;
    }

}
