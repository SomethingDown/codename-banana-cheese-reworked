using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__workspace_desk_node.svg")]
public partial class LevelManagerComponent : Node
{

    private Node2D level_container
    {
        get => LevelState.instance.level_container;
        set => LevelState.instance.level_container=value;
    }

    public override void _Ready()
    {
        EventsBus.instance.Subscribe(OnEvent);
    }
    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }


    public void OnEvent(Event e)
    {
        if (e is EventLevelLoadRequest level_load_event)
        {
            LoadNewLevel(level_load_event.level);
        }
        else if (e is EventLevelUnloadRequest level_unload_event)
        {
            UnloadLevel();
        }
        else if (e is EventLevelContainerRequest level_container_event)
        {
            SetLevelContainer(level_container_event.level_container);
        }
        
    }

    public void LoadNewLevel(Node2D level)
    {
        if (level == null) return;

        UnloadLevel();
        level_container?.AddChild(level);
        EventsQueue.instance.Publish(new EventLevelChanged(level));
    }

    public void UnloadLevel()
    {
        level_container?.GetChildren().ToList().ForEach(l=>{if(l is not IAmLevelContainer){level_container.RemoveChild(l);l.QueueFree();}});//Might cause issues so consider changingt to RemoveChild...
        EventsQueue.instance.Publish(new EventLevelChanged(null));
    }

    public void SetLevelContainer(Node2D container)
    {
        level_container = container;
        EventsQueue.instance.Publish(new EventLevelChanged(container));
    }

}
