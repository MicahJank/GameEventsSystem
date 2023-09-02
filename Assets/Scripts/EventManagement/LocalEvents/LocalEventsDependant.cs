
using UnityEngine;

[RequireComponent(typeof(LocalObjectEvents))]
public abstract class LocalEventsDependant : MonoBehaviour, ILocalEventsDependant
{
    protected EventBus localEvents;

    public virtual void OnLocalEventsInitialized(EventBus _localEvents)
    {
        localEvents = _localEvents;
    }
}
