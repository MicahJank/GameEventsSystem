
using UnityEngine;

[RequireComponent(typeof(LocalObjectEvents))]
public abstract class LocalEventsDependant : MonoBehaviour, ILocalEventsDependant
{
    protected EventBus localEventsReference;

    public virtual void OnLocalEventsInitialized(EventBus _localEvents)
    {
        localEventsReference = _localEvents;
    }
}
