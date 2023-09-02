using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float spawnRadius = 5;

    private int currentEnemyCount = 0;

    private void Awake()
    {
        GameEvents.RegisterListener<WaveBeginEvent>(OnWaveBegin);
        GameEvents.RegisterListener<EnemyDiedEvent>(OnEnemyDied);
    }

    private void OnWaveBegin(WaveBeginEvent args)
    {
        for (int i = 0; i < args.EnemyCount; i++)
        {
            Instantiate(EnemyPrefab, Random.insideUnitCircle * spawnRadius, Quaternion.identity);
        }

        currentEnemyCount = args.EnemyCount;
    }
    private void OnEnemyDied(EnemyDiedEvent args)
    {
        currentEnemyCount--;

        GameEvents.RaiseEvent<EnemiesAliveChangedEvent>(new EnemiesAliveChangedEvent(currentEnemyCount));
    }
}
