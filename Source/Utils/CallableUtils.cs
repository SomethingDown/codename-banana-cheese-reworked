
using System;
using Godot;

public static class callableUtils
{
    //CLAUDE AHH SOLUTION FOR ARBITRARY CALLABLE CREATION FOR SIGNAL!
    static public Callable CreateCallableForSignal(this Object obj,GodotObject source, string signalName, Action action)
    {
        int argCount = GetSignalArgCount(source, signalName);

        return argCount switch
        {
            0 => Callable.From(action),
            1 => Callable.From((Variant a) => action()),
            2 => Callable.From((Variant a, Variant b) => action()),
            3 => Callable.From((Variant a, Variant b, Variant c) => action()),
            4 => Callable.From((Variant a, Variant b, Variant c, Variant d) => action()),
            _ => throw new NotSupportedException($"Signal '{signalName}' has {argCount} args, add another case.")
        };
    }

    static public int GetSignalArgCount(GodotObject source, string signalName)
    {
        foreach (Godot.Collections.Dictionary signal in source.GetSignalList())
        {
            if ((string)signal["name"] == signalName)
            {
                var args = (Godot.Collections.Array)signal["args"];
                return args.Count;
            }
        }
        return 0;
    }

}