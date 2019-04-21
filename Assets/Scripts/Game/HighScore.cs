using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HighScore : MonoBehaviour {

	public static float highScore;
	private static int score;


	Scene getSceneName;
	private string activeScene;

	// Use this for initialization
	void Start () {

		//score = ((int)ScoreScript.Score);

		getSceneName = SceneManager.GetActiveScene ();
		activeScene = getSceneName.name;

		//MODIFY THIS
		switch (activeScene) {

		    case("book1Page1"):
			
			    highScoreInit ("book1page1HS");
			    break;

            case ("book1Page2"):

                highScoreInit("book1page2HS");
                break;

            case ("book1Page3"):

                highScoreInit("book1page3HS");
                break;

            case ("book2Page1"):

                highScoreInit("book1page3HS");
                break;

            default:
			    break;
		}


	}
	
	// Update is called once per frame
	void Update () {

		//MODIFY THIS
		switch (activeScene) {

		    case("book1Page1"):
			
			    highScoreManager ("book1Page1HS");
			    break;

            case ("book1Page2"):

                highScoreManager("book1Page2HS");
                break;

            case ("book1Page3"):

                highScoreManager("book1Page3HS");
                break;

            case ("book2Page1"):

                highScoreManager("book2Page1HS");
                break;

            case ("book2Page2"):

                highScoreManager("book2Page2HS");
                break;

            case ("book2Page3"):

                highScoreManager("book2Page3HS");
                break;

            default:
			
			break;

		}
		
						
	}


	private void highScoreInit(string HSInitKey){
	
	
		if (!PlayerPrefs.HasKey (HSInitKey)) {

			PlayerPrefs.SetInt(HSInitKey, 0);
			highScore = PlayerPrefs.GetInt (HSInitKey);

		}


		highScore = PlayerPrefs.GetInt (HSInitKey);
	
	
	}


	private void highScoreManager(string HSKey){
	
	
		highScore = PlayerPrefs.GetInt (HSKey);
		score = ((int)ScoreScript.Score);

		if (score > highScore) {

			PlayerPrefs.SetInt (HSKey, score);
			Debug.Log ("New HS");

			highScore = PlayerPrefs.GetInt (HSKey);

		}
	
	}
}
