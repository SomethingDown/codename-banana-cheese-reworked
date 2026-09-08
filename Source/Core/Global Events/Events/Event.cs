using System;
using System.Collections.Generic;
using Godot;

public record Event
{
    public DateTime date_time { get; private set; }

    protected Event()
    {
        date_time = DateTime.Now;
    }
}

public record EventMessage : Event
{
    public string message;
}

public record EventGameover : Event
{
    public HeistResultResource heist_result {get; private set;}
    public EventGameover(HeistResultResource heist_result) { this.heist_result = heist_result; }
}
