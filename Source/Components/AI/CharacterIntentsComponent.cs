using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__book_node.svg")]
public partial class CharacterIntentsComponent : Node
{
    public Vector2? target_position;
    public float? target_looking_rad;
    public ItemResource target_inventory_item;
    public bool is_started_using = false;
    public bool is_stopped_using = false;

}
