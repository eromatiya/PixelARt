using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorRotate : MonoBehaviour {

    private float rotationSpeed = 1000.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }
}
