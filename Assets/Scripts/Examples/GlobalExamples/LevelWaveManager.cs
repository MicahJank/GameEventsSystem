
using UnityEngine;

public class LevelWaveManager : MonoBehaviour
{
    [SerializeField] private float waveCountdownTimer = 3.0f;
    [SerializeField] private int minEnemies;
    [SerializeField] private int maxEnemies;

    private bool beginWaveCountdown = false;
    private float waveTimer;

    private void Awake()
    {
        GameEvents.RegisterListener<EnemiesAliveChangedEvent>(OnEnemiesAliveChanged);

        beginWaveCountdown = true;
    }
    private void Update()
    {
        if (beginWaveCountdown)
        {
            waveTimer += Time.deltaTime;

            Debug.Log($"Wave Countdown Time : {string.Format("{0:F1}", waveCountdownTimer - waveTimer)}");
            if (waveTimer > waveCountdownTimer)
            {
                BeginWave();
            }
        }
    }

    private void BeginWave()
    {
        waveTimer = 0;
        beginWaveCountdown = false;

        int enemyCount = Random.Range(minEnemies, maxEnemies);

        Debug.Log($"New Wave has Begun with {enemyCount} Enemies");

        GameEvents.RaiseEvent(new WaveBeginEvent(enemyCount));
    }
    private void OnEnemiesAliveChanged(EnemiesAliveChangedEvent args)
    {
        if (args.EnemiesAlive <= 0)
        {
            beginWaveCountdown = true;
        }
    }
}
