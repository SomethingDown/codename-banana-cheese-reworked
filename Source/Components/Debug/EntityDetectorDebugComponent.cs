using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class EntityDetectorDebugComponent : Node
{

    private EntityDetectorComponent entity_detector_;


    public override void _Ready()
    {
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        entity_detector_.EntityAreaEntered += e =>
        {
            EventsQueue.instance.Publish(new EventMessage{message=$"Entered: {
                string.Join(" ",e.entity.GetChildren().Select(n=>n.Name))
            }"});
        };
        entity_detector_.EntityAreaExited += e =>
        {
            EventsQueue.instance.Publish(new EventMessage{message=$"Exited: {e}"});
        };


    }

}
