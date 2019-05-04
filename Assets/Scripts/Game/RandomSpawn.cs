using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] spawnObjects;       // The enemy prefab to be spawned.
    public float spawnTime = 0.5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    Vector3 spawnScale;

    Scene sceneName;
    string activeScene; 

    // Use this for initialization
    void Start () {

        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;

        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }
	
	// Update is called once per frame
	void Update () {

      

    }


    void Spawn()
    {

        GameObject go;
        GameObject spawned;

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (spawnPoints[spawnPointIndex].childCount < 1)
        {
            spawned = spawnObjects[Random.Range(0, spawnObjects.Length)];
            //spawnScale = spawned.transform.localScale;
            if (spawned && activeScene == "book1Page3")
            {
                if (spawned.name == "mushroom1")
                {
                    spawnScale = new Vector3(15.0f, 15.0f, 15.0f);
                }
                else
                {

                    spawnScale = new Vector3(3.0f, 3.0f, 3.0f);
                }
            }

            go = Instantiate(spawned, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            go.transform.SetParent(spawnPoints[spawnPointIndex]);
			go.transform.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);

            if (activeScene == "book1Page3")
                go.transform.localScale = spawnScale;
        }
    }
}
