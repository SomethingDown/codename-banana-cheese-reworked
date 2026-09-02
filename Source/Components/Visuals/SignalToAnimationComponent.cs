using System.Linq;
using Godot;
using Godot.Collections;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/streamline__film_slate_node.svg")]
public partial class SignalToAnimationComponent : Node
{
    [Export] private Array<SignalToAnimationResource> signals_to_animations_ = new Array<SignalToAnimationResource>();
    public override void _Ready()
    {
        signals_to_animations_.ToList().ForEach(r =>
        {
            Node source = GetNodeOrNull(r.source_path);
            if (source == null) return;

            AnimationPlayer animation_player = GetNodeOrNull(r.animation_player_path) as AnimationPlayer;
            if (animation_player == null) return;
            
            source.Connect(r.signal_name, Callable.From(() => animation_player.Play(r.animation_name)));
        });
    }
}
