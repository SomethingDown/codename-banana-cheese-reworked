using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__paintbrush_node.svg")]
public partial class DisplayableResourcesSelectorUIComponent : Node
{

    [Export] private PackedScene texture_button_scene_;
    [Export] private InfoCardUI infocard_;
    [Export] private Control resources_container;

    private DisplayableResourcesSelectorComponent resource_selector_;
    private IDisplayableResourcesProvider resources_provider_;


    public override void _Ready()
    {
        resource_selector_ = this.GetComponent<DisplayableResourcesSelectorComponent>();
        if (resource_selector_ == null) return;

        resources_provider_ = this.GetComponent<IDisplayableResourcesProvider>();
        if (resources_provider_ == null) return;

        if (resources_container == null) return;
        
        if (infocard_ == null) return;

        resources_provider_.ResourcesChanged += OnResourcesChanged;
        OnResourcesChanged();
    }


    private void OnResourcesChanged()
    {
        ClearContainer();
        int index = 0;
        resources_provider_.GetResources().ToList().ForEach(r =>
        {
            LoadResource(r,index++);
        });
    }

    private void ClearContainer()
    {
        resources_container.GetChildren().ToList().ForEach(i_c=>i_c.QueueFree());
    }

    private void LoadResource(IDisplayableResource displayable_resource,int idx)
    {
        TextureButton item_option = texture_button_scene_.Instantiate<TextureButton>();

        if (item_option == null) return;

        item_option.TextureNormal = displayable_resource.Icon;

        item_option.Pressed += () =>
        {
            resource_selector_.SelectAt(idx);
            infocard_.title = displayable_resource.Name;
            infocard_.data = displayable_resource.Description;
            
        };

        resources_container.AddChild(item_option);
    }



}