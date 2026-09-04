using System;
using Godot;

[GlobalClass]
public partial class DamageIndicatorComponent : Node
{
    private DamageRecieverComponent damage_reciever_;
    private Random random_ = new Random();
    public override void _Ready()
    {
        damage_reciever_ = this.GetComponent<DamageRecieverComponent>();
        if (damage_reciever_ == null) return;

        Node2D entity = this.GetEntity() as Node2D;
        if(entity == null) return;

        damage_reciever_.Damaged += (d, i_v) =>
        {
            ProxyDraw2D indicator = new ProxyDraw2D();

            
            indicator.draw_handler = () =>
                {
                    indicator.DrawString(ThemeDB.FallbackFont,Vector2.Zero,$"{d}",HorizontalAlignment.Center, -1, 8, Colors.White);
                };
            
            Tween tween = indicator.CreateTween();

            GetTree().CurrentScene.AddChild(indicator);

            indicator.GlobalPosition = entity.GlobalPosition;
            float rng = random_.NextSingle();
            tween.SetParallel(true);
            tween.TweenMethod(
                Callable.From<float>(
                    (d)=>{indicator.GlobalPosition += new Vector2(rng*2 - 1,-1.0f)*1;}
                ),0,0,0.4
            );
            tween.TweenProperty(indicator,"modulate:a",0.0f,0.6f);
            tween.SetParallel(false);
            tween.Finished += ()=>indicator.QueueFree();
        };
    }


}
