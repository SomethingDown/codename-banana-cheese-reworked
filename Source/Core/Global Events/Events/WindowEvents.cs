
using Godot;

public record EventWindowLoadRequest : Event
{
    public Control content { get; private set; }
    public bool is_exit_button_hidden {get; private set;} = true;

    public EventWindowLoadRequest(Control content)
    {
        this.content = content;
    }
    public EventWindowLoadRequest(Control content,bool is_exit_button_hidden)
    {
        this.content = content;
        this.is_exit_button_hidden = is_exit_button_hidden;
    }
}

public record EventWindowUnloadRequest : Event
{
}

public record EventWindowChanged : Event
{
    public Control content { get; private set; }

    public EventWindowChanged(Control content)
    {
        this.content = content;
    }
}

public record EventWindowContainerRequest : Event
{
    public CanvasLayer window_container { get; private set; }

    public EventWindowContainerRequest(CanvasLayer window_container)
    {
        this.window_container = window_container;
    }
}

public record EventWindowContainerChanged : Event
{
    public CanvasLayer window_container { get; private set; }

    public EventWindowContainerChanged(CanvasLayer window_container)
    {
        this.window_container = window_container;
    }
}