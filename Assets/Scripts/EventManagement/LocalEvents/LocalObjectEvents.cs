
#region Using Statements

using System.Collections.Generic;
using UnityEngine;

#endregion

#region Event Dependants Interface

public interface ILocalEventsDependant
{
    void OnLocalEventsInitialized(EventBus _localEvents);
}

#endregion

[DisallowMultipleComponent]
public class LocalObjectEvents : MonoBehaviour
{
    #region Private Fields

    private EventBus localEvents;

    #endregion

    #region Initialization

    private void Awake()
    {
        localEvents = new EventBus();

        var parentComponents = gameObject.GetComponents<ILocalEventsDependant>();
        var childComponents = gameObject.GetComponentsInChildren<ILocalEventsDependant>();
        var allDependants = new List<ILocalEventsDependant>();

        allDependants.AddRange(parentComponents);
        allDependants.AddRange(childComponents);

        for (int i = 0; i < allDependants.Count; i++)
        {
            allDependants[i].OnLocalEventsInitialized(localEvents);
        }
    }

    #endregion
}

