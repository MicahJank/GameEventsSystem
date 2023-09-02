using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : LocalEventsDependant
{
    public override void OnLocalEventsInitialized(EventBus _localEvents)
    {
        base.OnLocalEventsInitialized(_localEvents);

        localEventsReference.RegisterListener<EnemyHealth.IsZeroEvent>(OnHealthZeroEvent);
    }

    private void OnHealthZeroEvent(EnemyHealth.IsZeroEvent args)
    {
        GameEvents.RaiseEvent(new EnemyDiedEvent());

        Debug.Log("Enemy Died!");

        Destroy(gameObject);
    }
}
