using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WaveBeginEvent : IEventDefinition
{
    public int EnemyCount
    {
        get;
        private set;
    }

    public WaveBeginEvent(int _enemyCount)
    {
        EnemyCount = _enemyCount;
    }
}
