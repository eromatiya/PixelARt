using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerEventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
        GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().onTargetFound();
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
        GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().onTargetLost();

    }





}




