using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPointP1;
    public Transform spawnPointP2;

    private int waveNumber = 0;

    public TurnManager manager;   
   
    public void Spawnwaver()
    {
        if (TurnManager.GetPlayerWithTurn() == null)
        {
            StartCoroutine(SpawnWave());
        }
    }


    public IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemies(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;

        if (waveNumber == waves.Length)
        {
            enabled = false;
        }

        yield return new WaitUntil(() => enemiesAlive <= 0);
        manager.SwitchTurn();
    }

    public void SpawnEnemies(GameObject enemy)
    {
        Instantiate(enemy, spawnPointP1.position, spawnPointP2.rotation);
        enemiesAlive++;
        Instantiate(enemy, spawnPointP2.position, spawnPointP2.rotation);
        enemiesAlive++;
    }


}
