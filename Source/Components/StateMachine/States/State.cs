using Godot;
using System;

public partial class State : Node
{
    public virtual void Enter(){}
    public virtual void Exit(){}
    public virtual State Update(){return null;}
}
