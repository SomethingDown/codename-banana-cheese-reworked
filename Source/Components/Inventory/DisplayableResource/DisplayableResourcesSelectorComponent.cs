using Godot;
using System;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/@icons__backpack_node.svg")]
public partial class DisplayableResourcesSelectorComponent : Node
{
    [Signal] public delegate void SelectionChangedEventHandler(GodotObject displayable_resource);

    private IDisplayableResourcesProvider resources_provider_;


    public IDisplayableResource selected_resource {get;private set;} = null;


    public override void _Ready()
    {
        resources_provider_ = this.GetComponent<IDisplayableResourcesProvider>();

        if (resources_provider_ == null) return;
        resources_provider_.ResourcesChanged += OnResourcesChanged;
    }

    public override void _ExitTree()
    {
        if (resources_provider_ == null) return;
        resources_provider_.ResourcesChanged -= OnResourcesChanged;
    }


    public void SelectAt(int index)
    {
        if (resources_provider_ == null) return;
        int count = resources_provider_.GetCount();
        if (count == 0)
        {
            SetSelected(null);
            return;
        }
        int wrapped = Mathf.Wrap(index,0,count);
        SetSelected(resources_provider_.GetAt(wrapped));
    }

    public void SelectNext() => SelectAt(IndexOfSelected() + 1);

    public void SelectPrevious() => SelectAt(IndexOfSelected() - 1);

    public void Unselect() => SetSelected(null);

    private int IndexOfSelected()
    {
        if (resources_provider_ == null) return -1;
        return resources_provider_.GetResources().IndexOf(selected_resource);
    }


    private void SetSelected(IDisplayableResource displayable_resource)
    {
        if (selected_resource == displayable_resource) return;
        selected_resource = displayable_resource;
        EmitSelectionChangedSignal();
    }

    private void EmitSelectionChangedSignal()
    {
        EmitSignal(SignalName.SelectionChanged, selected_resource as GodotObject);
    }

    private void OnResourcesChanged()
    {
        int index = IndexOfSelected();
        if (index == -1)
        {
            Unselect();
            return;
        }
        SelectAt(index);
    }

}