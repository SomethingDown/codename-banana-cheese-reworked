using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class SignalToAlertComponent : Node
{
    [Export] private Node source;
    [Export] private string signal;

    public override void _Ready()
    {
        if (source == null) return;
        try
        {
            Connect(signal,this.CreateCallableForSignal(source,signal,OnSignal));
        }
        catch (System.Exception e)
        {
            EventsQueue.instance.Publish(new EventMessage($"{e}"));
            throw;
        }
    }

    private void OnSignal()
    {
    }


}
