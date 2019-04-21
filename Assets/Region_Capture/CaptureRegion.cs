using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureRegion : MonoBehaviour {
    
    private bool sourceExists = false;

	// Use this for initialization
	void Start () {

        

		
	}
	
	// Update is called once per frame
	void Update () {

        if (!sourceExists) {

            GameObject videoSource;
            videoSource = GameObject.Find("Video source 0");

            if (videoSource) {

                GameObject GO;

                GO = Instantiate(videoSource) as GameObject;
                GO.transform.SetParent(transform);
                GO.tag = "RegionPlane";
                GO.name = "RegionPlane";
                GO.layer = 20;
                GO.transform.localPosition = new Vector3(0.0f, -0.4f, 1.08f);
                sourceExists = true;
            }
             
            

        }


	}
}
