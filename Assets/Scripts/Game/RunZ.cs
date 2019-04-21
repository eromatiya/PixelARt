//Script's purpose is to move environment in game
//Attached to Environment obj

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunZ : MonoBehaviour {

    private float origSpeed = 1.0f;
    private float Speed = 1.0f;
    public GameObject model;

    // Use this for initialization
	void Start () {

        //Save original position

        //Make env to run
        StartGame();
        

    }

    // Update is called once per frame
    void Update () {

        //Check if Game is Over
        if (model.GetComponent<HitObstacle>().isOver == true)
        {
           
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            return;

        }


        //Pause Game
        if (GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing == false)
            Paused();

    }


    //Start Running Game
    public void StartGame()
    {
		ResetSpeed ();
		RunNow();
    }

    //Paused Running game
    private void Paused()
    {
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
    }

    //Set speed base on difficulty
    public void SetSpeed(float SpeedUp)
    {
		float speeder;

		speeder = SpeedUp * 0.025f;

		Debug.Log (speeder);

        //Set Speed 
		Speed += speeder;

		//speed up the run
		RunNow();



    }

    public void ResetSpeed()
    {
        Speed = origSpeed;
    }

	public void RunNow(){
	
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -Speed);

	}


}
