using Godot;
using System;

[GlobalClass]
public partial class HeistSelectorInfoCardDisplayerUI : Node
{
    [Export] private InfoCardUI info_card_;
    private HeistSelectorComponent heist_selector_;

    public override void _Ready()
    {
        heist_selector_ = this.GetComponent<HeistSelectorComponent>();
        if (heist_selector_ == null) return;

        if (info_card_ == null) return;

        heist_selector_.SelectionChanged += (h) =>
        {
            info_card_.title = h.name;
            info_card_.data = h.description;
        };
    }
}
