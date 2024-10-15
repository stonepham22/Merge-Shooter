using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Objects that want to subscribe to an event must implement this interface
/// </summary>
public interface IObserver
{
    /// <summary>
    /// The event subject will call this method when an event occurs to notify all event listener objects.
    /// </summary>
    /// <param name="type">The type of event that the subject wants to notify</param>
    /// <param name="data">The data that the subject wants to pass to the event listener objects</param>
    void Notify(EventType type, object data);
}
