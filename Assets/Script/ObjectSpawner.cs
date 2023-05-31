using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;    // Prefab of the object to spawn
    public float spawnInterval = 2f;    // Time interval between spawns
    private float timer = 0f;
    private GameObject playerObject;    // Reference to the player object
    public TimeSurvived Survived;
    
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
       
        
    }

    private void Update()
    {
        // Check if the player object exists
        if (playerObject == null)
        {
            // Player object does not exist, so stop spawning
            Survived.Gameover();
            
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f));
        GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }




}
