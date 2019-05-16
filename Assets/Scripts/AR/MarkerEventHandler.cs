using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerEventHandler : MonoBehaviour {

	GameObject uiController;

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectWithTag ("Controller")) {
		
			uiController = GameObject.FindGameObjectWithTag ("Controller");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMarkerFound(ARMarker marker) {

        /*
        if (marker.Tag.Equals("Marker1"))
        {
            //Do something
        }
        */

        Debug.Log("Marker found!");

        uiController.GetComponent<UserInterfaceButtons>().onTargetFound();
    }

    
    void OnMarkerTracked(ARMarker marker)
    {
        
        if (marker.Tag.Equals("Marker1"))
        {
            //Do something each frame
        }
    }
        

    void OnMarkerLost(ARMarker marker)
    {
        /*
        if (marker.Tag.Equals("Marker1"))
        {
            //Do something each frame
        }
        */
        Debug.Log("Marker lost!");
        uiController.GetComponent<UserInterfaceButtons>().onTargetLost();

    }





}




