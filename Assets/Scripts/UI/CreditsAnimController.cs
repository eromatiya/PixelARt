using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimController : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartCreditsScene(){

		anim.Play ("CreditsAnim");
		//anim.SetTrigger ("goToEmpty");

	}

	public void StopCreditsAnimScene(){

		anim.Play ("CreditsAnim", -1, 0f);
	}
}
