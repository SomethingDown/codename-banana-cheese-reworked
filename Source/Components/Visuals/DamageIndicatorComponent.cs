using System;
using Godot;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class DamageIndicatorComponent : Node
{
    [Export] private Font font_;
    [Export] private int font_size_ = 8;
    [Export] private Color color_ = Colors.White;
    [Export] private float rise_distance_ = 1.0f;
    [Export] private float rise_duration_ = 0.4f;
    [Export] private float fade_duration_ = 0.6f;

    private DamageRecieverComponent damage_reciever_;
    private Random random_ = new Random();

    public override void _Ready()
    {
        damage_reciever_ = this.GetComponent<DamageRecieverComponent>();
        if (damage_reciever_ == null) return;

        Node2D entity = this.GetEntity() as Node2D;
        if (entity == null) return;

        damage_reciever_.Damaged += (d, i_v) =>
        {
            ProxyDraw2D indicator = new ProxyDraw2D();

            Font font = font_ ?? ThemeDB.FallbackFont;

            indicator.draw_handler = () =>
            {
                indicator.DrawString(font, Vector2.Zero, $"{d}", HorizontalAlignment.Center, -1, font_size_, color_);
            };

            Tween tween = indicator.CreateTween();

            GetTree().CurrentScene.AddChild(indicator);

            indicator.GlobalPosition = entity.GlobalPosition;
            float rng = random_.NextSingle();
            tween.SetParallel(true);
            tween.TweenMethod(
                Callable.From<float>(
                    (d) => { indicator.GlobalPosition += new Vector2(rng * 2 - 1, -1.0f) * rise_distance_; }
                ), 0, 0, rise_duration_
            );
            tween.TweenProperty(indicator, "modulate:a", 0.0f, fade_duration_);
            tween.SetParallel(false);
            tween.Finished += () => indicator.QueueFree();
        };
    }
}