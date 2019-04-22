//This script is for Gameover dialog
//It is attached to GameController Object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text playerScoreTxt;
    public Text playerStarsTxt;
	public Text highScoreTxt;


	private static int starNumber;

//	public GameObject gameController;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		starNumber = PlayerPrefs.GetInt ("starTotal");

        playerScoreTxt.GetComponent<Text>().text = ((int)ScoreScript.Score).ToString();
		playerStarsTxt.GetComponent<Text> ().text = starNumber.ToString ();
		highScoreTxt.GetComponent<Text> ().text = HighScore.highScore.ToString ();
    }
}
