using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.Events;
=======
using static UnityEngine.GraphicsBuffer;

public enum SpawnPoints
{
    SpawnPoint1 = 0,
    SpawnPoint2 = 1,
    SpawnPoint3= 2,
    SpawnPoint4 = 3,
}
>>>>>>> main

public class SpawnEnemies : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemyPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float diffScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecCap = 15f;

    [Header("Events")]
    public static UnityEvent onEnemyDeath = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private float eps;
    private int enemyAlive;
    private int enemyLeftToSpawn;
    private bool isSpawning = false;
    public static SpawnEnemies main;
    //public GameObject enemyType;
    public float spawnFrequency;
    public SpawnPoints spawnPoint;
    [SerializeField] private LevelManager levelManager;
    private int index;



    // Start is called before the first frame update

    private void Awake()
    {
        onEnemyDeath.AddListener(EnemyDeath);
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / eps) && enemyLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemyLeftToSpawn--;
            enemyAlive++;
            timeSinceLastSpawn = 0f;
        }

        if(enemyAlive == 0 && enemyLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDeath()
    {
        enemyAlive--;
    }
    void Start()
    {
<<<<<<< HEAD
        StartCoroutine(StartWave());
        //InvokeRepeating("SpawnEnemy", 0.0f, spawnFrequency);
=======
        //Debug.Log(spawnPoint);

        switch (spawnPoint)
        {
            //Debug.Log(spawnPoint);
            case SpawnPoints.SpawnPoint1:
                index = 0;
                break;
            case SpawnPoints.SpawnPoint2:
                index = 1;
                break;
            case SpawnPoints.SpawnPoint3:
                index = 2;
                break;
            case SpawnPoints.SpawnPoint4:
                index = 3;
                break;

        }

        InvokeRepeating("SpawnEnemy", 0.0f, spawnFrequency);


>>>>>>> main
    }

    void SpawnEnemy()
    {
<<<<<<< HEAD
        int index = Random.Range(0, enemyPrefab.Length);
        GameObject prefabToSPawn = enemyPrefab[index];
        Instantiate(prefabToSPawn,LevelManager.main.startPoint.position, Quaternion.identity);
        //Instantiate(enemyType, transform);
    }

    private int EnemeiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, diffScalingFactor));
    }

    private float EnemiesPerSeconds()
    {
        return Mathf.Clamp((enemyPerSecond * Mathf.Pow(currentWave, diffScalingFactor)), 0f, enemiesPerSecCap);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        isSpawning = true;
        enemyLeftToSpawn = EnemeiesPerWave();
        eps = EnemiesPerSeconds();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
=======
        Instantiate(enemyType, levelManager.startPoint[index]);
    }

    public SpawnPoints GetSpawnPoint()
    {
        return spawnPoint;
    }
        
>>>>>>> main
}
