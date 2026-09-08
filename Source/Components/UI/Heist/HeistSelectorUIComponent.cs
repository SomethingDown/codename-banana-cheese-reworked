using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class HeistSelectorUIComponent : Node
{

    [Export] private Control heists_container_;
    [Export] private PackedScene pretty_button_ui_;
    
    private HeistSelectorComponent heist_selector_component_;

    public override void _Ready()
    {
        if (heists_container_ == null) return;
        if (pretty_button_ui_ == null) return;
        
        heist_selector_component_ = this.GetComponent<HeistSelectorComponent>();
        if (heist_selector_component_ == null) return;

        HeistResource hr = GD.Load<HeistResource>("res://Resources/Heists/TrainingHeist.tres");
        EventsQueue.instance.Publish(new EventHeistAddRequest(hr));
        EventsQueue.instance.Publish(new EventHeistUnlockRequest(hr));

        EventsBus.instance.Subscribe(OnEvent);

        OnUnlockedHeists( HeistState.instance.GetUnlockedHeists());
    }

    public void OnEvent(Event e)
    {
        switch (e)
        {
            case EventHeistsUnlocked h_u:
                OnUnlockedHeists(h_u.unlocked_heists);
                break;

            default:
                break;
        }
    }

    public override void _ExitTree()
    {
        EventsBus.instance.Unsubscribe(OnEvent);
    }


    public void OnUnlockedHeists(List<HeistResource> unlocked_heists)
    {
        heists_container_.GetChildren().ToList().ForEach(h => h.QueueFree());
        unlocked_heists.ForEach(h =>
        {
            CenterPivotTextureButtonUI pretty_button = pretty_button_ui_.Instantiate<CenterPivotTextureButtonUI>();
            pretty_button.TextureNormal = h.icon;
            pretty_button.Pressed += ()=>{heist_selector_component_.select(h);};
            heists_container_.AddChild(pretty_button);
        });

    }

}
