using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour {

	public GameObject model;

	private float moveDuration = 1f;


	private float positionMid = 0.35f;
	private float positionLeft = 0.6f;
	private float positionRight = 0.1f;

	float z;
	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {

		z = transform.localPosition.z;

		if (GameObject.FindGameObjectWithTag ("Model")) {

			model = GameObject.FindGameObjectWithTag ("Model");
		}

	}

	// Update is called once per frame
	void Update () {


		if (model.transform.position.x == -0.25f && transform.position.x != positionRight) {

			StartCoroutine (MirrorPlayer ("right"));

		}

		if (model.transform.position.x == 0.25f && transform.position.x != positionLeft) {

			StartCoroutine (MirrorPlayer ("left"));
		}

		if (model.transform.position.x == 0.0f && transform.position.x != positionMid) {
					
			StartCoroutine (MirrorPlayer ("mid"));
		}
	}



	private IEnumerator MirrorPlayer(string moveTo){
	
		float step;

		switch (moveTo) {

		case "right":

			step = moveDuration * Time.deltaTime;
			startPos = transform.localPosition;
			endPos = new Vector3 (startPos.x = positionRight, transform.localPosition.y, transform.localPosition.z);
			gameObject.transform.localPosition = Vector2.MoveTowards (startPos, endPos, step);
			endPos.z = z;
			transform.localPosition = endPos;
			yield return null;
			break;

		case "left":
			
			step = moveDuration * Time.deltaTime;
			startPos = transform.localPosition;
			endPos = new Vector3 (startPos.x = positionLeft, transform.localPosition.y, transform.localPosition.z);
			gameObject.transform.localPosition = Vector2.MoveTowards (startPos, endPos, step);
			endPos.z = z;
			transform.localPosition = endPos;
			yield return null;
			break;

		case "mid":

			step = moveDuration * Time.deltaTime;
			startPos = transform.localPosition;
			endPos = new Vector3 (startPos.x = positionMid, transform.localPosition.y, transform.localPosition.z);
			gameObject.transform.localPosition = Vector2.MoveTowards (transform.localPosition, endPos, step);
			endPos.z = z;
			transform.localPosition = endPos;
			yield return null;	
			break;
		}


	}
}
