using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimController : MonoBehaviour {

	private Animator anim;
	private float speed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		speed = anim.speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartCreditsScene(){

		anim.Play ("CreditsAnim");
		anim.speed = speed;
	}

	public void StopCreditsAnimScene(){

		anim.Play ("CreditsAnim", -1, 0f);
		anim.speed = 0;
		anim.SetTrigger ("goToEmpty");
	}
}
