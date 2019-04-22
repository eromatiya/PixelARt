using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCAlign : MonoBehaviour {

    public GameObject ARController;

	// Use this for initialization
	void Start () {

        float transformX;
        float transformZ;
        transformZ = ARController.GetComponent<ARMarker>().NFTHeight / 10.0f;
        transformX = ARController.GetComponent<ARMarker>().NFTWidth / 10.0f;
        gameObject.transform.localScale = new Vector3(transformX, transformZ, transformZ);
        Debug.Log(transformX);
        Debug.Log(transformZ);

        float positionX;
        float positionZ;
        positionX = ((transformX / 2) * 10.0f);
        positionZ = ((transformZ / 2) * 10.0f);
        gameObject.transform.localPosition = new Vector3(positionX, 0.0f, positionZ);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
