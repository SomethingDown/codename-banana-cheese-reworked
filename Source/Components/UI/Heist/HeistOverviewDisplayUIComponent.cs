using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class HeistOverviewDisplayUIComponent : Node
{
    [Export] private InfoCardUI time_info_;
    [Export] private InfoCardUI kills_info;
    [Export] private InfoCardUI currency_info;
    [Export] private InfoCardUI status_info;


    public override void _Ready()
    {
        HeistResultResource results = HeistState.instance.GetHeistLog().LastOrDefault();

        if (results == null) return;

        if (time_info_ != null)
        {
            TimeSpan elapsed = results.end_time - results.start_time;
            time_info_.data = $"{elapsed.Minutes}:{elapsed.Seconds} Minutes";
        }

        if (kills_info != null)
        {
            kills_info.data = $"{results.kills}";
        }

        if (currency_info != null)
        {
            currency_info.data = $"{results.currency}$";
        }
        if (status_info != null)
        {
            status_info.data = $"{results.end_result}";
        }
    }


}
