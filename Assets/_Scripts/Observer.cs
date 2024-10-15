using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// The Observer class is responsible for managing observers and notifying them of events.
/// </summary>
public static class Observer
{
    /// <summary>
    /// Using a HashSet as the value in the dictionary to avoid 
    /// a listener being added multiple times for the same event.
    /// </summary>
    private static Dictionary<Type, HashSet<IObserver>> dicListeners = new Dictionary<Type, HashSet<IObserver>>();

    public static void Regist(Type type, IObserver listener)
    {
        if (!dicListeners.TryGetValue(type, out var listeners))
        {
            listeners = new HashSet<IObserver>();
            dicListeners[type] = listeners;
        }
        listeners.Add(listener);
    }
    public static void Regist(List<Type> types, IObserver listener)
    {
        foreach (Type type in types)
        {
            Regist(type, listener);
        }
    }

    public static void Unregist(Type type, IObserver listener)
    {
        if (dicListeners.TryGetValue(type, out var listeners))
        {
            listeners.Remove(listener);
        }
    }
    public static void Unregist(List<Type> types, IObserver listener)
    {
        foreach (Type type in types)
        {
            Unregist(type, listener);
        }
    }

    public static void Notify(Type type, object data)
    {
        if (dicListeners.TryGetValue(type, out var listeners))
        {
            foreach (IObserver listener in listeners)
            {
                listener.Notify(type, data);
            }
        }
        
    }
}