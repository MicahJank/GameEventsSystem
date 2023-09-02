using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemiesAliveChangedEvent : IEventDefinition
{
    public int EnemiesAlive
    {
        get;
        private set;
    }

    public EnemiesAliveChangedEvent(int _enemiesAlive)
    {
        EnemiesAlive = _enemiesAlive;
    }
}
