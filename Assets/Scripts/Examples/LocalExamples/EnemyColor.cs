using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : LocalEventsDependant
{
    [SerializeField] private Gradient statusColorGradient;

    private SpriteRenderer sRenderer;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.color = statusColorGradient.Evaluate(0f);
    }

    public override void OnLocalEventsInitialized(EventBus _localEvents)
    {
        base.OnLocalEventsInitialized(_localEvents);

        localEventsReference.RegisterListener<EnemyHealth.ValueChangedEvent>(OnEnemyHealthChanged);
    }

    private void OnEnemyHealthChanged(EnemyHealth.ValueChangedEvent args)
    {
        sRenderer.color = statusColorGradient.Evaluate(1 - args.HealthPercentage);
    }
}
