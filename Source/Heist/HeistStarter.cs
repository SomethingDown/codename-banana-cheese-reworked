using Godot;
using System;

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
            EventsQueue.instance.Publish(new EventHeistLaunchRequested(heist_selector_.selected_heist, transfer_inventory_));
        };
    }
}