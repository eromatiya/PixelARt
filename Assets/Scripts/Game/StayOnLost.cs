using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnLost : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StayOnMarkerLost(){

		gameObject.GetComponent<ARTrackedObject> ().secondsToRemainVisible = Mathf.Infinity;
	}

	public void HideOnMarkerLost(){

		gameObject.GetComponent<ARTrackedObject> ().secondsToRemainVisible = 0;
	}
}
