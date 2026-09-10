using Godot;
using Godot.Collections;


[GlobalClass]
public partial class ItemResource : Resource , IDisplayableResource
{
    [Export]public string name;
    [Export]public string description;
    [Export]public Texture2D icon;

    [Export]public float base_price;
    [Export]public ItemType item_type = ItemType.Other;
    [Export]public PackedScene item_equipped_scene;
    [Export]public Array<AuthorizationResource> authorizations = new Array<AuthorizationResource>();

    public string Name {get=>name;set=>name=value;}
    public string Description  {get=>description;set=>description=value;}
    public Texture2D Icon {get=>icon;set=>icon=value;}

}

public enum ItemType
{
    Weapon,
    Other
}
