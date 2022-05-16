using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject playerCont;

    public GameObject enemyPrefabs;
    public GameObject powerUpPreFab;

    private float spawnRange = 9f;

    public int nEnemiesInScene;

    public int enemyWaveCount;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize wave count = 0
        enemyWaveCount = 0;
        SpawnEnemyWave(3);
        Instantiate(powerUpPreFab, GenerateSpawmnPosition(), powerUpPreFab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        // Be carful: FindObjectsOfType & FindObjectOfType
        // Objects vs Objects
        nEnemiesInScene = FindObjectsOfType<Enemy>().Length;

        // If Enemy cout is == 0 Spawn 1 new enemy 
        if (nEnemiesInScene == 0)
        {

            enemyWaveCount++;
            SpawnEnemyWave(enemyWaveCount);
            Instantiate(powerUpPreFab, GenerateSpawmnPosition(), powerUpPreFab.transform.rotation);
          
        }
    }

    //IEnumerator PowerupCountdownRoutine()

    //{
    //    yield return new WaitForSeconds(4);
    //    enemyWaveCount++;

    //}


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawmnPosition(), enemyPrefabs.transform.rotation);
        }
    }

    private Vector3 GenerateSpawmnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
        
    }
    
}
