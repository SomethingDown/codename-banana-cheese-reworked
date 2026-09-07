using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class HeistStarter : Node
{
    [Export] private HeistAcceptChecker heist_accept_checker_;
    [Export] private HeistSelectorComponent heist_selector_;
    [Export] private InventoryComponent transfer_inventory_;

    public override void _Ready()
    {
        if (heist_accept_checker_ == null) return;
        if (heist_selector_ == null) return;

        heist_accept_checker_.HeistRequestAccepted += () =>
        {
            PlayerState.instance.transfer_Inventory_component = transfer_inventory_;
            HeistManager.instance.SetCurrentHeist(heist_selector_.selected_heist);
            AsyncUtils.InvokeNextFrame(()=>{
                
                Node2D level = heist_selector_.selected_heist.scene.Instantiate<Node2D>();
                if (level == null )return;

                EventsQueue.instance.Publish(new EventLevelLoadRequest(level));
                EventsQueue.instance.Publish(new EventWindowUnloadRequest());
            });
            
        };
    }



}
