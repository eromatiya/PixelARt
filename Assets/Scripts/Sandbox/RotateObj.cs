using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour {


	float rotSpeed = 10;
	public bool rotateMode = false;
	private GameObject grabbedObject;
	private bool rotateNow = false;
    private Vector3 prefabScale;
    private Touch touch;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (rotateMode)
        {

            if (Input.touchCount > 0)
            {
                touch = Input.touches[0];
                Vector3 pos = Input.mousePosition;

                if (touch.phase == TouchPhase.Began)
                {

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(pos);

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity) && (hit.collider.tag == "Sands" || hit.collider.tag == "Model"))
                    {
                        
                        grabbedObject = hit.collider.gameObject;
                        rotateNow = true;

                    }

                }
            }

            if (rotateNow && touch.phase == TouchPhase.Moved)
            {

                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                grabbedObject.transform.RotateAround(Vector3.up, -rotX);
            }
        }

    }

	public void modeRotateOn(){
	
		rotateMode = true;
	}

	public void modeRotateOff(){
		
		rotateMode = false;

	}
}
