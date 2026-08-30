using Godot;


[GlobalClass]
public partial class UseDisability : Node, IUse
{
    public bool Use(Node user)
    {
        CharacterMovementComponent character_movement_component = user.GetComponentInEntity<CharacterMovementComponent>();
        if (character_movement_component == null) return false;
        character_movement_component.enabled = false;
        user.AddComponentInEntity<YappingComponent>();
        return true;
    }
    public bool UseAlternative(Node user)
    {
        return false;
    }

    }
