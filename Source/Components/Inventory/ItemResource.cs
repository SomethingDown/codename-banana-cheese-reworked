using Godot;
using System;


[GlobalClass]
public partial class ItemResource : Resource
{
    [Export]public string name;
    [Export]public string description;
    [Export]public ItemType item_type = ItemType.Other;
    [Export]public PackedScene item_equipped_scene;

}

public enum ItemType
{
    Weapon,
    Other
}
