using System;
using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__signal_node.svg")]
public partial class DamageRecieverComponent : Node
{

    [Signal] public delegate void DamagedEventHandler(float damage,Vector2 impact_velocity,ulong source_id);

    public void Damage(float damage,Vector2 impact_velocity,ulong source_id)
    {
        EmitSignal(SignalName.Damaged,damage,impact_velocity,source_id);
    }


}
