using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 5;
    private float sideSpawnZMin = 5;
    private float sideSpawnZMax = 15;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int direction = Random.Range(0, 3); // 0: Ön, 1: Sol, 2: Sağ

        Vector3 spawnPos;
        Quaternion spawnRotation;

        switch (direction)
        {
            case 0: // Önden hayvan çıkıyor.
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
                spawnRotation = Quaternion.identity;  // Default rotasyon
                break;

            case 1: // Soldan hayvan çıkıyor.
                spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(sideSpawnZMin, sideSpawnZMax));
                spawnRotation = Quaternion.Euler(0, 90, 0); // Sağa doğru döndürülmüş rotasyon
                break;

            case 2: // Sağdan hayvan çıkıyor.
                spawnPos = new Vector3(spawnRangeX, 0, Random.Range(sideSpawnZMin, sideSpawnZMax));
                spawnRotation = Quaternion.Euler(0, -90, 0); // Sola doğru döndürülmüş rotasyon
                break;

            default:
                spawnPos = new Vector3(0, 0, 0); 
                spawnRotation = Quaternion.identity;
                break;
        }

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRotation);
    }
}


