using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TerrainGrassInstance : MonoBehaviour {

	//public GameObject graphicsButton;
	private string enableGrass;

	// Use this for initialization
	void Start () {

		CheckQuality ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CheckQuality(){
		
		enableGrass = PlayerPrefs.GetString ("GraphicsMode");

		if (enableGrass == "Low" || enableGrass == "Medium") {
			gameObject.GetComponent<Terrain> ().drawTreesAndFoliage = false;
		} else {
			gameObject.GetComponent<Terrain> ().drawTreesAndFoliage = true;
		}

	}

	public void EnGrassInstance(bool enable){
		
		gameObject.GetComponent<Terrain> ().drawTreesAndFoliage = enable;
	}

}
