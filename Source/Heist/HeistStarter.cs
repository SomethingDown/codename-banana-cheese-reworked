using Godot;
using System;

[GlobalClass]
public partial class HeistStarter : Node
{
    [Export] private HeistAcceptChecker heist_accept_checker_;
    [Export] private DisplayableResourcesSelectorComponent heist_selector_;
    [Export] private InventoryComponent transfer_inventory_;

    public override void _Ready()
    {
        if (heist_accept_checker_ == null) return;
        if (heist_selector_ == null) return;

        heist_accept_checker_.HeistRequestAccepted += () =>
        {
            HeistResource heist_resources = heist_selector_.selected_resource as HeistResource;
            if (heist_resources == null) return;
            EventsQueue.instance.Publish(new EventHeistLaunchRequested(heist_resources, transfer_inventory_));
        };
    }
}