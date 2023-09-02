
#region Using Statements

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

#region IEventDefinition Interface

public interface IEventDefinition { }

#endregion

#region Event Delegate

public delegate void EventBusDelegate<T>(T gameEvent) where T : struct, IEventDefinition;

#endregion

public class EventBus
{
    #region Event Registry

    private Dictionary<Type, Delegate> eventRegistry;

    #endregion

    #region Constructor

    public EventBus()
    {
        eventRegistry = new Dictionary<Type, Delegate>();
    }

    #endregion

    #region Register Method

    public void RegisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEventDefinition
    {
        var t = typeof(T);
        if (eventRegistry.TryGetValue(t, out Delegate d))
        {
            eventRegistry[t] = Delegate.Combine(d, eventDelegate);
        }
        else
        {
            eventRegistry.Add(t, eventDelegate);
        }
    }
    public void RemoveListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEventDefinition
    {
        var t = typeof(T);
        if (eventRegistry.TryGetValue(t, out Delegate d))
        {
            Delegate currentDelegate = Delegate.Remove(d, eventDelegate);

            if (currentDelegate == null)
            {
                eventRegistry.Remove(t);
            }
            else
            {
                eventRegistry[t] = currentDelegate;
            }
        }
    }

    #endregion

    #region Raise Method

    public void RaiseEvent<T>(in T eventData) where T : struct, IEventDefinition
    {
        if (eventRegistry.TryGetValue(typeof(T), out Delegate d))
        {
            EventBusDelegate<T> actionDelegate = d as EventBusDelegate<T>;
            actionDelegate?.Invoke(eventData);
        }
    }

    #endregion
}