using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numberOfCoins = 10;
    public float spawnInterval = 2f; // Time interval between each coin spawn
    public Transform playerTransform; // Reference to the player object's transform
    private GameObject playerObject;
   
    private void Start()
    {
        StartCoroutine(SpawnCoins());
       
            playerObject = GameObject.FindGameObjectWithTag("Player");
       
    }

    public  IEnumerator SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector3 position = GenerateRandomPosition();
            GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);

            //// Make the coin follow the player object
            //Airplane coinFollower = coin.GetComponent<Airplane>();
            //coinFollower.SetTarget(playerTransform);

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private void Update()
    {


        if(playerObject==null)
        {
            StopCoroutine(SpawnCoins());
        }

        

    }

   
    private Vector2 GenerateRandomPosition()
    {
        // Generate a random position within your gameplay area
        // Example:
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(0f, 15f);
        
        return new Vector2(x, y);
    }


}
