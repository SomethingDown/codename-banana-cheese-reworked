using Godot;
using System.Linq;

[GlobalClass]
public partial class BrainComponent : Node
{
    private Decision prefered_decision_ ;
    private float prefered_decision_score_ ;


    public override void _Process(double delta)
    {
        Decision new_prefered_decision_ = null;
        float new_prefered_decision_score_ = 0.0f;
        GetChildren().ToList().ForEach(n =>
        {
           Decision decision = n as Decision;
           if (decision == null) return;

            float score = decision.GetScore();
            if (score == 0.0f) return;
            if (score > new_prefered_decision_score_) 
            {
                new_prefered_decision_ = decision;
                new_prefered_decision_score_ = score;
            }
        });
        if (new_prefered_decision_ != prefered_decision_)
        {
            prefered_decision_?.Exit();
            prefered_decision_ = new_prefered_decision_;
            prefered_decision_?.Enter();

            EventsQueue.instance.Publish(new EventMessage{message=$"{prefered_decision_?.Name}"});
        }
        prefered_decision_?.Execute();
    }


}
