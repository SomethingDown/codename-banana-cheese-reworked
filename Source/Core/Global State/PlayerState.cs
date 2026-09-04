using Godot;
using System;

public class PlayerState
{
    
    static private PlayerState instance_ = new PlayerState();
    static public PlayerState instance => instance_;

    public Node player_entity = null;

    public void SubscribePlayer(Node entity) => player_entity = entity;
    public void UnsubscribePlayer() => player_entity = null;

}
