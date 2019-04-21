using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] spawnObjects;       // The enemy prefab to be spawned.
    public float spawnTime = 0.5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }
	
	// Update is called once per frame
	void Update () {

      

    }


    void Spawn()
    {

        GameObject go;
        Vector3 spawnScale;
        GameObject spawned;

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (spawnPoints[spawnPointIndex].childCount < 1)
        {
            spawned = spawnObjects[Random.Range(0, spawnObjects.Length)];
            //spawnScale = spawned.transform.localScale;
            if (spawned.name == "mushroom1")
            {
                spawnScale = new Vector3(15.0f, 15.0f, 15.0f);
            }
            else {

                spawnScale = new Vector3(3.0f, 3.0f, 3.0f);
            }
            go = Instantiate(spawned, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            go.transform.SetParent(spawnPoints[spawnPointIndex]);
            go.transform.localScale = spawnScale;
        }
    }
}
