using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimController : MonoBehaviour {

	private Animator anim;
	private float speed;
	Touch touch;
	public CanvasGroup aboutPanel;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		speed = anim.speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (aboutPanel.alpha == 1) {
		
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary || (Input.GetMouseButton (0)) && anim.speed != 0) {
			
				anim.speed = 5.0f;
			} else {
			
				anim.speed = speed;
			}
		}
		
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
