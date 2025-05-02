using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{

    public Wave[] waves;
    public int nextWave = 0;

    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float waveCountdown;

    private enum SpawningStates { Spawning, Waiting, Counting }
    private SpawningStates state;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        state = SpawningStates.Counting;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveCountdown <= 0)
        {
            if(state != SpawningStates.Spawning)
            {
                // start spawning
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
}


[System.Serializable]
public class Wave
{
    public string name;
    public GameObject[] enemies;
    public int amountOfEnemies;
    public float spawnDelay;
}