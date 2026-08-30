using System;
using System.Collections.Generic;


public class EventsQueue 
{
    static private EventsQueue instance_ = new EventsQueue();
    static public EventsQueue instance => instance_;

    private Queue<Event> events_ = new Queue<Event>();

    public void Publish(Event event_)
    {
        if (event_ == null) return;
        events_.Enqueue(event_);
    }

    public void FlushAll(Action<Event> handler)
    {
        while (events_.Count > 0)
        {
            handler.Invoke(events_.Dequeue()); 
        }
    }

}
