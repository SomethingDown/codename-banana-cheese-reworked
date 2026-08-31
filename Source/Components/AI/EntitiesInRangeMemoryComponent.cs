using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/pixelarticons__memory_stick_pixel_node.svg")]
public partial class EntitiesInRangeMemoryComponent : Node
{
    private EntityDetectorComponent entity_detector_;


    public List<EntityAreaComponent> entities = new List<EntityAreaComponent>();


    public override void _Ready()
    {
        entity_detector_ = this.GetComponent<EntityDetectorComponent>();
        if (entity_detector_ == null) return;
        entity_detector_.EntityAreaEntered += e =>
        {
            entities.Add(e);
        };
        entity_detector_.EntityAreaExited += e =>
        {
            entities.Remove(e);
        };
    }
}
