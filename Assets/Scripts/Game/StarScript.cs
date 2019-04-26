using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StarScript : MonoBehaviour {


    //coordinates
    //x = 0.94 left
    //x = 0.53 mid
    //x = 0.14 right

    private Scene sceneName;
    private string activeScene;


	private static int starTotalGet;
	private static int starOnPlay;

    // Use this for initialization
    void Start () {

        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
        
	
		if (!PlayerPrefs.HasKey ("starTotal")) {

			PlayerPrefs.SetInt ("starTotal", 0);

		}


	}
	
	// Update is called once per frame
	void Update () {

        if (activeScene != "book3Page2")
        {
            //Rotate Stars hehe for cooler effects
            transform.Rotate(0, 120 * Time.deltaTime, 0);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Model")
        {
			//get the total of stars collected
			starTotalGet = PlayerPrefs.GetInt ("starTotal");

            //Add 5 Points 
            ScoreScript.Score += 5;

            //Add Star
            ScoreScript.StarCount++;

			StarManager ();

			Destroy(gameObject);
        }
    }

	//add star on your pockets
	private void StarManager(){
	

		starTotalGet++;
		PlayerPrefs.SetInt ("starTotal", starTotalGet);
	//	Debug.Log ("Star: " + PlayerPrefs.GetInt ("starTotal"));
	
	}




}
