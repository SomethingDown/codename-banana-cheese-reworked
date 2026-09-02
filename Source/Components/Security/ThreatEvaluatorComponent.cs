using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class ThreatEvaluatorComponent : Node
{
    [Signal] public delegate void ThreatDetectedEventHandler(Node entity);
    [Signal] public delegate void ThreatClearedEventHandler(Node entity);

    private List<Node> last_threats_ = new List<Node>();

    private EntitiesLOSMemoryComponent entities_los_memory_;

    public override void _Ready()
    {
        entities_los_memory_ = this.GetComponent<EntitiesLOSMemoryComponent>();
    }

    public override void _PhysicsProcess(double delta)
    {
        List<Node> threats = new List<Node>();
        entities_los_memory_.GetEntitiesInLOSWithComponent<AuthorizationComponent>().ToList().ForEach(e =>
        {
            var auth_comp = e.entity.GetComponentInEntity<AuthorizationComponent>();
            if (auth_comp == null) return;

            var requiredAuths = GetRequiredAuthorizations(e.entity);

            bool unauthorized = requiredAuths.Any(a => !auth_comp.authorizations.Contains(a));

            if (unauthorized)
            {
                threats.Add(e);
            }
        });
        threats.ForEach(e =>
        {
            if (!last_threats_.Contains(e)) EmitSignal(SignalName.ThreatDetected,e);
        });
        last_threats_.ForEach(e =>
        {
            if (!threats.Contains(e)) EmitSignal(SignalName.ThreatCleared,e);
        });
        last_threats_ = threats;
    }

    private List<AuthorizationResource> GetRequiredAuthorizations(Node entity)
    {
        var result = new List<AuthorizationResource>();

        var item_selector = entity.GetComponentInEntity<ItemSelectorComponent>();
        if (item_selector?.selected_item != null)
        {
            result.AddRange(item_selector.selected_item.authorizations);
        }
        
        var interactor_comp = entity.GetComponentInEntity<InteractorComponent>();
        if (interactor_comp?.interaction != null)
        {
            result.AddRange(interactor_comp.interaction.authorizations);

        }

        return result;
    }







}
