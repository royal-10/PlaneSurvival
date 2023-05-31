using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject objectPrefab;              // Prefab of the object to be pooled
    public int poolSize = 10;                     // Initial size of the object pool

    private List<GameObject> objectPool;         // List to hold the pooled objects

    private void Start()
    {
        objectPool = new List<GameObject>();

        // Populate the object pool with pooled objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transform);
            newObject.SetActive(true);
            objectPool.Add(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        // Search for an inactive object in the pool and return it
        foreach (GameObject pooledObject in objectPool)
        {
            if (!pooledObject.activeInHierarchy)
            {
                return pooledObject;
            }
        }

        // If all objects are active, create a new object and add it to the pool
        GameObject newObject = Instantiate(objectPrefab, transform);
        newObject.SetActive(false);
        objectPool.Add(newObject);
        return newObject;

    }


   

}
