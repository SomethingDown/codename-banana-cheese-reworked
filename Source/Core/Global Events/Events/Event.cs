

using System;
using Godot;

public record Event{}
public record EventMessage : Event {public string message;}
public record EventEntityDead : Event {
    public string name{get;private set;}
    public DateTime date_time {get;private set;} 
    public EventEntityDead(string name)
    {
        this.name=name;
        date_time = DateTime.Now;
    }
}