using Godot;
using System;

public interface IUse
{
    public bool UseInitiaited(Node user);
    public bool UseCanceled(Node user);

    public bool UseAlternativeInitiaited(Node user);
    public bool UseAlternativeCanceled(Node user);

}
