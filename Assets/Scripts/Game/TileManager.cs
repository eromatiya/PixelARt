using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] TilePrefabs;

    private Transform EnvironmentTransform;

    private int amtTileOnScr = 3;
    private float Marker = -5.0f;
    private int LastPrefabIndex = 0;

    private List<GameObject> ActiveTiles;

	private int preserveTUntil = 0;

    private bool isNormal = true;

    // Use this for initialization

    void Start()
    {
        //Create a list of spawned tiles
        ActiveTiles = new List<GameObject>();

        //Get transform of env
        EnvironmentTransform = gameObject.GetComponentInParent<Transform>().transform;
 
    }


    // Update is called once per frame
    void Update()
    {
        //Spawn tiles
        if (((int)EnvironmentTransform.position.z) < Marker)
        {
            if (isNormal)
            {
                SpawnTile(0);
                isNormal = false;

            } else { SpawnTile(); }

            Marker -= 5.0f;

			//Fixes the bug - overlapping tiles to each other
			preserveTUntil++;
			if (preserveTUntil > amtTileOnScr) {
				DeleteTile();
			}

        }
    }


    //Tile Generation Manager
    private void SpawnTile(int PrefabIndex = -1)
    {
        GameObject GO;
        if (PrefabIndex == -1)
        {
            GO = Instantiate(TilePrefabs[RandomizePrefabIndex()]) as GameObject;
        }
        else
        {
            GO = Instantiate(TilePrefabs[PrefabIndex]) as GameObject;
        }


        GO.transform.SetParent(transform);
        GO.transform.position = new Vector3(-0.35f, 0.0f, 5.0f);
        ActiveTiles.Add(GO);
    }

	//Destroy all children of TileManager obj
	public void KillTileChildren()
	{
		//Debug.Log(transform.childCount);
		int i = 0;

		//Array to hold all child obj
		GameObject[] allChildren = new GameObject[transform.childCount];

		//Find all child obj and store to that array
		foreach (Transform child in transform)
		{
			allChildren[i] = child.gameObject;
			i += 1;
		}

		//Now destroy them
		foreach (GameObject child in allChildren)
		{
			DestroyImmediate(child.gameObject);
		}

		//Debug.Log(transform.childCount);

		preserveTUntil = 0;

        //make normal spawn again
        isNormal = true;
	}


    // Destroy Tiles to Free Memory
    private void DeleteTile()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }


    public void StopSpawn()
    {
        //Hackish way to fix the bugs hahahahah
        DeleteTile();
        DeleteTile();
        DeleteTile();
        SpawnTile();
        SpawnTile();
    }


    //Randomize Tile Generation
    private int RandomizePrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
        {
            return 0;
        }
        int RandomIndex = LastPrefabIndex;
        while(RandomIndex == LastPrefabIndex)
        {
            RandomIndex = Random.Range(0, TilePrefabs.Length);
        }
        LastPrefabIndex = RandomIndex;
        return RandomIndex;
    }
}
