

using Godot;

public class EventsBus
{
    static private EventsBus instance_ = new EventsBus();
    static public EventsBus instance => instance_;

    public void Update()
    {
        EventsQueue.instance.FlushAll(Resolve);
    }

    private void Resolve(Event event_)
    {
        GD.Print($"[Event Bus]-{event_}");
    }
}