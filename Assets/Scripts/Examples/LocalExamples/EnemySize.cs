using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySize : LocalEventsDependant
{
    [SerializeField] private Vector2 minSize;
    [SerializeField] private Vector2 maxSize;

    private void Awake()
    {
        transform.localScale = maxSize;
    }

    public override void OnLocalEventsInitialized(EventBus _localEvents)
    {
        base.OnLocalEventsInitialized(_localEvents);

        localEventsReference.RegisterListener<EnemyHealth.ValueChangedEvent>(OnEnemyHealthChanged);
    }

    private void OnEnemyHealthChanged(EnemyHealth.ValueChangedEvent args)
    {
        transform.localScale = Vector2.Lerp(minSize, maxSize, args.HealthPercentage);
    }
}
