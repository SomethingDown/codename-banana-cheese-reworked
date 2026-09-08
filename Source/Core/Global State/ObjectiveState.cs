using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ObjectiveState : Node
{
    static private ObjectiveState instance_ = new ObjectiveState();
    static public ObjectiveState instance => instance_;
    
    public List<ObjectiveResource> Objectives = new List<ObjectiveResource>();
    public List<ObjectiveResource> Secured_objectives = new List<ObjectiveResource>();


}
