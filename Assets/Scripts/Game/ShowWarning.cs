using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWarning : MonoBehaviour {

	public GameObject warning;
	public GameObject obstacle;

	// Use this for initialization
	void Start () {

		Invoke ("HideWarning", 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HideWarning(){
	
		warning.SetActive (false);
		obstacle.SetActive (true);

	}
}
