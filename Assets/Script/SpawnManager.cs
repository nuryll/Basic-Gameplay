using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    public float spawnRangeY = 5f; // Range in Y where animals can spawn
    private float spawnPosZ = 20;

    private float nextSpawnTime = 0f;
    public float spawnCooldown = 3f;
    public float animalSpeed = 5f;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnAnimal();
            nextSpawnTime = Time.time + spawnCooldown;
        }

    }

    void SpawnAnimal()
    {
        // Randomly choose whether to spawn from the left (-1) or the right (1)
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector3 spawnPosition = new Vector3(-direction * 10, 5.0f, Random.Range(-spawnRangeY, spawnRangeY));
        GameObject animal = Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], spawnPosition, Quaternion.identity);

        // Move the animal towards the opposite side
        animal.transform.LookAt(new Vector3(direction * 10, 5.0f, spawnPosition.z));
       
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
