using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

    public static float Score = 0;
    public static int StarCount = 0;


    private int DiffLvl = 1;
    private int MaxDiffLvl = 20;
    private int ScrToNxtLvl = 50;

    bool Play;

    public GameObject ScoreBoard;
    public GameObject StarBoard;
    public GameObject Environment;

    private Scene sceneName;
    private string activeScene;

    // Use this for initialization
    void Start () {

        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;

    }
	
	// Update is called once per frame
	void Update () {


        //ah you can understand it
        Play = gameObject.GetComponent<UserInterfaceButtons>().Playing;


        //if score is greater than given Score to Next level, call LevelUp()
		if (Score >= ScrToNxtLvl) {
			LevelUp ();
			//Debug.Log (DiffLvl);
		}


        //Add Score On Run!
        if (Play == false)
        {
            Score += 0;
        }
        else
        {
            if (activeScene != "book1Page3")
            {
                Score += Time.deltaTime * DiffLvl;
            }
        }
        
            
        //Update Scoreboard
        if(Play == true)
        {
           
            ScoreBoard.GetComponent<Text>().text = ((int)Score).ToString();
            StarBoard.GetComponent<Text>().text = StarCount.ToString();

        }

    }

    void LevelUp()
    {

        //Return if max difficulty reached
        if (DiffLvl == MaxDiffLvl)
            return;

        ScrToNxtLvl *= 2;

        //LevelUp!
		DiffLvl++;

        //Set speed by difficulty
        if (Play == true)
        {
            Environment.GetComponent<RunZ>().SetSpeed(DiffLvl);
        }
        

    }

    public void ResetScores()
    {
        Score = 0;
        StarCount = 0;
        DiffLvl = 1;
		ScrToNxtLvl = 10;
    }
}
