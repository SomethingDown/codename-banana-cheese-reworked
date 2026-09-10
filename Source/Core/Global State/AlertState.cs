using Godot;
using System;
using System.Collections.Generic;

public class AlertState
{
    static private AlertState instance_ = new AlertState();
    static public AlertState instance => instance_;

    public bool is_enabled = true;


}