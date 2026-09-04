using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class UseSteal : Node, IUse
{

    public bool UseInitiaited(Node user)
    {
        CurrencyComponent currency_component = user.GetComponentInEntity<CurrencyComponent>();
        if (currency_component == null) return false;

        EntitiesLOSMemoryComponent entities_los_memory_ = user.GetComponentInEntity<EntitiesLOSMemoryComponent>();
        if (entities_los_memory_ == null) return false;
        
        List<Node> entities = entities_los_memory_.GetEntitiesInLOSWithComponent<CurrencyComponent>();
        entities = entities.Where(e=>e.GetComponentInEntity<CurrencyComponent>().GetCurrency() > 0 ).ToList();
        
        if (entities.Count <= 0) return false;
        currency_component.AddCurrency(entities.First().GetComponentInEntity<CurrencyComponent>().SpendAllCurrency());
        
        return false;
    }
    public bool UseCanceled(Node user)=>false;

    public bool UseAlternativeInitiaited(Node user)=>false;
    public bool UseAlternativeCanceled(Node user)=>false;

}
