using Godot;

[GlobalClass]
public partial class KnockbackOnDamageComponent : Node
{
    private DamageRecieverComponent damage_reciever_;

    private Tween tween_;

    public override void _Ready()
    {
        damage_reciever_ = this.GetComponent<DamageRecieverComponent>();
        if (damage_reciever_ == null) return;

        Node2D entity = this.GetEntity() as Node2D;
        if(entity == null) return;

        damage_reciever_.Damaged += (d, i_v) =>
        {
            tween_?.Kill();
            tween_ = CreateTween();
            tween_.TweenMethod(
                Callable.From<float>(
                    w=>{entity.GlobalPosition+=i_v;}
                ),0,0,0.02
            );
        };
 
    }

}
