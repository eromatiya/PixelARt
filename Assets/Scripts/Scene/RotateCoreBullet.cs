using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoreBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {

		transform.Rotate(0, 360 * Time.deltaTime, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 360 * Time.deltaTime, 0);
	}
}
