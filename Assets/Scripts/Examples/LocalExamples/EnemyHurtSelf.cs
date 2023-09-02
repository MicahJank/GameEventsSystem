using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtSelf : LocalEventsDependant
{
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    [SerializeField] private float damageRate;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > damageRate)
        {
            int damageRoll = Random.Range(minDamage, maxDamage);

            localEventsReference.RaiseEvent(new EnemyHealth.DealDamageEvent(damageRoll));

            timer = 0;
        }
    }

}
