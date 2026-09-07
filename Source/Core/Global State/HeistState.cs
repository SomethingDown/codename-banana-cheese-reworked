using Godot;
using System;
using System.Collections.Generic;

public class HeistState
{
    static private HeistState instance_ = new HeistState();
    static public HeistState instance => instance_;

    public List<HeistResource> heists = new List<HeistResource>();
    public List<HeistResource> unlocked_heists = new List<HeistResource>();
    public HeistResource selected_heist = null;
}