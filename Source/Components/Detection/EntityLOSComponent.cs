using Godot;
using Godot.Collections;
using System.Collections.Generic;

using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__eye_node2d.svg")]
public partial class EntityLOSComponent : Node2D
{
    private List<RayCast2D> raycasts_;
    public override void _Ready()
    {
        raycasts_ = GetChildren().OfType<RayCast2D>().ToList<RayCast2D>();
        raycasts_.ForEach(r =>
        {
            r.CollisionMask = PhysicsLayers.Entities | PhysicsLayers.Common;
            r.CollideWithBodies = true;
            r.CollideWithAreas = true;
        });
    }


    public bool IsEntityInLOS(EntityAreaComponent entity_area_component)
    {

        LookAt(entity_area_component.GlobalPosition);

        bool detected = false;

        raycasts_.ForEach(r=>{r.ForceRaycastUpdate();if (r.GetCollider() == entity_area_component) detected = true;});

        return detected;
            
    }

}
