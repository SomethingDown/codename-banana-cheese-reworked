using Godot;
using System;
using System.Collections.Generic;

public partial class HeistResultResource : Resource
{
    public HeistResource heist;
    public DateTime start_time;
    public DateTime end_time;
    public float currency;
    public int kills;
    public HeistEndState end_result;
    public InventoryComponent inventory_used;
}
