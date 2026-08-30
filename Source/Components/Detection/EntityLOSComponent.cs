using Godot;
using Godot.Collections;
using System.Collections.Generic;

using System.Linq;

[GlobalClass]
public partial class EntityLOSComponent : Node2D
{
    private List<RayCast2D> raycasts_;
    public override void _Ready()
    {
        raycasts_ = GetChildren().OfType<RayCast2D>().ToList<RayCast2D>();
    }


    public bool IsEntityInLOS(EntityAreaComponent entity_area_component)
    {

        LookAt(entity_area_component.GlobalPosition);

        bool detected = false;

        raycasts_.ForEach(r=>{r.ForceRaycastUpdate();if (r.GetCollider() == entity_area_component) detected = true;});

        return detected;
            
    }

}
