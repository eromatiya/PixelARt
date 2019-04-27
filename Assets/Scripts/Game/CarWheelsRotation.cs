using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelsRotation : MonoBehaviour {


    public GameObject[] wheels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing == true)
        {

            wheels[0].transform.Rotate(1440 * Time.deltaTime, 0, 0);
            wheels[1].transform.Rotate(1440 * Time.deltaTime, 0, 0);
            wheels[2].transform.Rotate(1440 * Time.deltaTime, 0, 0);
            wheels[3].transform.Rotate(1440 * Time.deltaTime, 0, 0);

        }


    }
}
