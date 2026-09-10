

using System;
using System.Collections.Generic;
using Godot;

public class EventsBus
{
    static private EventsBus instance_ = new EventsBus();
    static public EventsBus instance => instance_;
    
    private List<Action<Event>> observer_callbacks = new List<Action<Event>>();

    public void Subscribe(Action<Event> callback)
    {
        observer_callbacks.Add(callback);

    }

    public void Unsubscribe(Action<Event> callback)
    {
        observer_callbacks.Remove(callback);
    }

    public void Update()
    {
        EventsQueue.instance.FlushAll(Resolve);
    }


    private void Resolve(Event event_)
    {
        var callbacks_snapshot = observer_callbacks.ToArray();

        foreach (var c in callbacks_snapshot)
        {
            try { c.Invoke(event_); }
            catch (System.Exception e) { GD.PrintErr($"Event observer threw: {e}"); }
        }
    }

}