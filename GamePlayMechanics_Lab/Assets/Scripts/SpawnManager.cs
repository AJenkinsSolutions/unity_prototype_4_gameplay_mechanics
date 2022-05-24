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
        // how many enemies in scene ?
        // Be carful: FindObjectsOfType & FindObjectOfType
        // Objects vs Objects
        nEnemiesInScene = FindObjectsOfType<Enemy>().Length;

        // If Enemy cout is == 0 Spawn 1 new enemy 
        if (nEnemiesInScene == 0)
        {
            //Increment the Wave/level count
            enemyWaveCount++;
            // spawn enemies equal wave count 
            SpawnEnemyWave(enemyWaveCount);
            //Spawn PowerUp
            Instantiate(powerUpPreFab, GenerateSpawmnPosition(), powerUpPreFab.transform.rotation);
          
        }
    }

    

    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //Takes int enemiesToSpawn as input
        //For i in enemiesToSPawn instantiate a new enemy
        //Generate a spawn position
        for (int i = 0; i < enemiesToSpawn; i++)
        {
           
            Instantiate(enemyPrefabs, GenerateSpawmnPosition(), enemyPrefabs.transform.rotation);
        }
    }

    private Vector3 GenerateSpawmnPosition()
    {
        //Generate random spawn position on the X Axis
        //Generate Random spawn position on the Z Axis
        //Assign new Vector3 RandomPos
        //Return New RandomPosition 
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
        
    }
    
}
