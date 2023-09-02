
#region Using Statements

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

public static class GameEvents
{
    #region EventBus

    private static EventBus eventBus = new EventBus();

    #endregion

    #region Register Method

    public static void RegisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEventDefinition
    {
        eventBus.RegisterListener<T>(eventDelegate);
    }

    #endregion

    #region Raise Method

    public static void RaiseEvent<T>(in T eventData) where T : struct, IEventDefinition
    {
        eventBus.RaiseEvent<T>(eventData);
    }

    #endregion
}