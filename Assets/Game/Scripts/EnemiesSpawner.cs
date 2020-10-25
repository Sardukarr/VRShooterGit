using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] int numberOfSpawnPonts = 100;
    [SerializeField] Transform spawnPointContainer;
    [SerializeField] Transform enemiesContainer;
    Vector3[] spawnPoints;
     



    void Start()
    {
       spawnPoints = new Vector3[numberOfSpawnPonts];
        // spawnPoints = spawnPointContainer.g
        RandomizeSpawnPoints();
        InvokeRepeating("Spawn", spawnTime, spawnTime);



    }



    void RandomizeSpawnPoints()
    {
       for(int i=0; i<numberOfSpawnPonts; i++)
        {
            int x = Random.Range(-250, 250);
            int z = Random.Range(-250, 250);
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

        Instantiate(enemy, spawnPoints[spawnPointIndex], new Quaternion(0f,0f,0f,0f));
    }
}
