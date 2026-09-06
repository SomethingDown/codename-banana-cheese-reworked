using Godot;
using System;

[GlobalClass]
public partial class HeistStarter : Node
{
    [Export] private HeistAcceptChecker heist_accept_checker_;
    [Export] private HeistSelectorComponent heist_selector;

    public override void _Ready()
    {
        if (heist_accept_checker_ == null) return;
        if (heist_selector == null) return;

        heist_accept_checker_.HeistRequestChecked += b =>
        {
            if (b==false) return;

            HeistManager.instance.SetCurrentHeist(heist_selector.selected_heist);
            AsyncUtils.InvokeNextFrame(this,()=>{
                GameState.instance.LoadNewLevel(heist_selector.selected_heist.scene.Instantiate<Node2D>());
                WindowManager.instance.UnloadNewWindow();
            });
            
        };
    }



}
