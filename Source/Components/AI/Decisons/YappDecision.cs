using Godot;
using System;

[GlobalClass]
public partial class YappDecision : Decision
{
    [Export] public string quote;
    public override void Execute()
    {
        EventsQueue.instance.Publish(new EventMessage{message=$"{quote}"});
    }

}
