using Godot;

[GlobalClass]
public partial class DamageRecieverComponent : Node
{

    [Signal] public delegate void DamagedEventHandler(float damage,Vector2 impact_velocity);

    public void Damage(float damage,Vector2 impact_velocity)
    {
        EmitSignal(SignalName.Damaged,damage,impact_velocity);
    }


}
