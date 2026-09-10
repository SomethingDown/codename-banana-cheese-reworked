using Godot;
using System;

public record EventAlertRequest : Event
{
    public Node threat;
    public float bonus;

    public EventAlertRequest(Node threat,float bonus)
    {
        this.threat = threat;
        this.bonus = bonus;
    }
}
public record EventAlert : Event
{
    public Node threat;
    public float bonus;
    public EventAlert(Node threat,float bonus)
    {
        this.threat = threat;
        this.bonus = bonus;
    }
}
public record EventAlertStateChangeRequest : Event
{
    public bool state;

    public EventAlertStateChangeRequest(bool state)
    {
        this.state = state;
    }
}

public record EventAlertStateChanged : Event
{
    public bool state;

    public EventAlertStateChanged(bool state)
    {
        this.state = state;
    }
}


