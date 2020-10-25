using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime = 2f;

    // podzielne przez 4
    int numberOfSpawnPonts = 100;
    [SerializeField] int mapWidth = 200;
    [SerializeField] Transform spawnPointContainer;
    [SerializeField] Transform enemiesContainer;
    Vector3[] spawnPoints;
     



    void Start()
    {
       spawnPoints = new Vector3[numberOfSpawnPonts];
        // spawnPoints = spawnPointContainer.g
        RandomizeSpawnPoints(0, numberOfSpawnPonts/4,100, mapWidth, -mapWidth, mapWidth);
        RandomizeSpawnPoints(numberOfSpawnPonts / 4, numberOfSpawnPonts / 2, -mapWidth, -100, -mapWidth, mapWidth);
        RandomizeSpawnPoints(numberOfSpawnPonts / 2, numberOfSpawnPonts *3/4, -mapWidth, mapWidth, 100, mapWidth);
        RandomizeSpawnPoints(numberOfSpawnPonts * 3 / 4, numberOfSpawnPonts, -mapWidth, mapWidth, -mapWidth, -100);
        InvokeRepeating("Spawn", spawnTime, spawnTime);



    }



    void RandomizeSpawnPoints(int from, int to, int minX, int maxX, int minZ, int maxZ )
    {
       for(int i= from; i< to; i++)
        {

            int x = Random.Range(minX, maxX);
            int z = Random.Range(minZ, maxZ);
          //  GameObject newSpawn = new GameObject();
          //  newSpawn.transform.position = new Vector3(x, 0, z);

            spawnPoints[i] = new Vector3(x, 0, z);
            //  newSpawn.transform.parent = spawnPointContainer;
        }
        
       // int random

    }

    void Spawn()
    {
    //    if (playerHealth.currentHealth <= 0f)
     //   {
       //     return;
     //   }

        int spawnPointIndex = Random.Range(0, numberOfSpawnPonts);

        GameObject newEnemy =Instantiate(enemy, spawnPoints[spawnPointIndex], new Quaternion(0f,0f,0f,0f));
        newEnemy.transform.parent = enemiesContainer;
    }
}
