using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    //! Public variables
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveCountdownText;

    //! Private variables
    private float countdown = 2f;
    private int waveNumber = 0;

    void Update()
    {
        //! Reset and spawn enemies 
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    //! Spawn enemies according to the wave count.
    IEnumerator SpawnWave()
    {
        waveNumber++;
        Debug.Log("New Wave");
        for(int i=0; i< waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    //! Enemy object Instantiation
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
