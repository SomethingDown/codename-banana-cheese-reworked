using Godot;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__brain_node.svg")]
public partial class BrainComponent : Node
{
    [Signal] public delegate void DecisionChangedEventHandler(Decision decision); 
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
            if (prefered_decision_!=null) EmitSignal(SignalName.DecisionChanged,prefered_decision_);
        }
        prefered_decision_?.Execute();
    }


}
