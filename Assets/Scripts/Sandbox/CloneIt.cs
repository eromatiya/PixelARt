using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloneIt : MonoBehaviour {
	private GameObject GO;
	private GameObject cloneIt;
	private Vector3 prefabScale;
	private Vector3 prefabPosition;
	private RaycastHit hit;
	public bool toggleClone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(toggleClone){
		Plane targetPlane = new Plane (transform.up, transform.position);

			foreach(Touch touch in Input.touches) {
			

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

					Ray ray = Camera.main.ScreenPointToRay (touch.position);



					float dist = 0.0f;
					targetPlane.Raycast (ray, out dist);
					Vector3 planePoint = ray.GetPoint (dist);

					if (!IsPointerOverUIObject () && cloneIt != null) {
						
						if (!Physics.Raycast (ray, out hit) || hit.collider.gameObject.tag == "SandsTerrain") {


							Vector3 tempPlanePoint;
							GO = Instantiate (cloneIt) as GameObject;
							GO.transform.SetParent (transform);
							planePoint.y = prefabPosition.y;
							GO.transform.position = planePoint;
						}

					}

					if (Physics.Raycast (ray, out hit)) {


						if (hit.collider.tag == "Sands") {
						
							cloneIt = hit.collider.gameObject;
							prefabPosition = cloneIt.transform.localPosition;
						}


					}

				}

			}
		}
	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}


	public void cloneToggleOn(){
	
		toggleClone = true;

	}

	public void cloneToggleOff(){
		toggleClone = false;
	}
}
