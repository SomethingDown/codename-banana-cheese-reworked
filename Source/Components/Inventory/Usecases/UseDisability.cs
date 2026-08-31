using Godot;


[GlobalClass]
public partial class UseDisability : Node, IUse
{
    private float timer_;
    private bool started_;
    public bool UseInitiaited(Node user)
    {
        timer_ = 0.0f;
        started_ = true;
        return false;
    }
    public bool UseCanceled(Node user)
    {
        EventsQueue.instance.Publish(new EventMessage{message=$"Canceled after: {timer_}s"});
        timer_ = 0.0f;
        started_ = false;
        return true;
    }
    public bool UseAlternativeInitiaited(Node user)
    {
        CharacterMovementComponent c = user.GetComponentInEntity<CharacterMovementComponent>();
        c.enabled = false;
        return false;
    }
    public bool UseAlternativeCanceled(Node user)
    {
        CharacterMovementComponent c = user.GetComponentInEntity<CharacterMovementComponent>();
        c.enabled = true;
        return false;
    }


    public override void _PhysicsProcess(double delta)
    {
        if (started_==false) return;
        timer_+=(float)delta;
    }


    
    }
