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
    public List<HeistResultResource> heist_log = new List<HeistResultResource>();

    public List<HeistResource> GetHeists() => heists;
    public List<HeistResource> GetUnlockedHeists() => unlocked_heists;
    public HeistResource GetSelectedHeist() => selected_heist;
    public List<HeistResultResource> GetHeistLog() => heist_log;

}