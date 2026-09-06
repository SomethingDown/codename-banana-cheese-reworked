using System;
using System.Linq;
using Godot;
using Godot.Collections;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__link_node.svg")]
public partial class SignalToTweenComponent : Node
{
    [Export] private Array<SignalToTweenResource> tweens_ = new Array<SignalToTweenResource>();
    private TweenComponent tween_component_;

    public override void _Ready()
    {
        tween_component_ = this.GetComponent<TweenComponent>();
        if (tween_component_ == null) return;

        tweens_.ToList().ForEach(entry =>
        {
            Node source = GetNodeOrNull(entry.source_path);
            if (source == null) return;
            
        source.Connect(
            entry.signal_name,
            this.CreateCallableForSignal(
                source,
                entry.signal_name,
                () => tween_component_.InitiateTween(entry.tween_resources)));
            });
    }


}