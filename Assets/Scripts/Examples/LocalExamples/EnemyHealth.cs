using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : LocalEventsDependant
{
    public struct DealDamageEvent : IEventDefinition
    {
        public int Damage
        {
            get;
            private set;
        }

        public DealDamageEvent(int _damage)
        {
            Damage = _damage;
        }
    }
    public struct ValueChangedEvent : IEventDefinition
    {
        public int HealthValue
        {
            get;
            private set;
        }
        public float HealthPercentage
        {
            get;
            private set;
        }

        public ValueChangedEvent(int _healthValue, float _healthPercentage)
        {
            HealthValue = _healthValue;
            HealthPercentage = _healthPercentage;
        }
    }
    public struct IsZeroEvent : IEventDefinition
    {

    }

    [SerializeField] private int maxHealth;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public override void OnLocalEventsInitialized(EventBus _localEvents)
    {
        base.OnLocalEventsInitialized(_localEvents);

        localEventsReference.RegisterListener<DealDamageEvent>(DealDamage);
    }

    public void DealDamage(DealDamageEvent args)
    {
        currentHealth -= args.Damage;

        if (currentHealth <= 0)
        {
            localEventsReference.RaiseEvent(new IsZeroEvent());
        }
        else
        {
            localEventsReference.RaiseEvent(new ValueChangedEvent(currentHealth, (float)currentHealth / (float)maxHealth));
        }
    }
}
