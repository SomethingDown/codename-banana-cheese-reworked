using Godot;
using Godot.Collections;


[GlobalClass]
public partial class ItemResource : Resource
{
    [Export]public string name;
    [Export]public string description;
    [Export]public ItemType item_type = ItemType.Other;
    [Export]public PackedScene item_equipped_scene;
    [Export]public Array<AuthorizationResource> authorizations = new Array<AuthorizationResource>();
}

public enum ItemType
{
    Weapon,
    Other
}
