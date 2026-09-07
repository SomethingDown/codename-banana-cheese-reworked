using Godot;
using System;

public class LevelState
{
    static private LevelState instance_ = new LevelState();
    static public LevelState instance => instance_;

    public Node2D level_container;


}
