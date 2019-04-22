using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StarSound : MonoBehaviour {


	private AudioSource ClickSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip StarCling; 


	// Use this for initialization
	void Start () {
		
		gameObject.AddComponent<AudioSource>();
		ClickSource.clip = StarCling;
		ClickSource.playOnAwake = false;
		ClickSource.volume = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider star){

		if (star.gameObject.tag == "Star") {
			//Debug.Log ("Cling");
			ClickSource.PlayOneShot (StarCling);

		}


	}





}
