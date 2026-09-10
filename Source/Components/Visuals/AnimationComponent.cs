using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class AnimationComponent : AnimationTree
{

    private List<AnimationParameter> animation_parameters_ = new List<AnimationParameter>(); 

    public override void _Ready()
    {
        ChildEnteredTree += OnAddedParameter;
        Initialization();
    }

    public override void _PhysicsProcess(double delta)
    {
        animation_parameters_.ForEach(
            p =>
            {
                Set($"parameters/{p.parameter_name}/blend_position",p.GetValue());
            }
        );
    }

    private void Initialization()
    {
        animation_parameters_.Clear();
        GetChildren().ToList().ForEach(n =>
        {
            AnimationParameter anim_par = n as AnimationParameter;
            if (anim_par == null) return;
            animation_parameters_.Add(anim_par);
        });
        
    }

    public void OnAddedParameter(Node node)
    {
        AnimationParameter anim_par = node as AnimationParameter;

        if (anim_par == null) return;

        animation_parameters_.Add(anim_par);
    }




}
