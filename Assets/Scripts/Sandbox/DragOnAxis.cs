using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragOnAxis : MonoBehaviour {

	public GameObject transformAxis;

	private RaycastHit hit;

	private Touch touch;

	private Ray ray;

	private GameObject GO;

	private Transform dragObject;

	private string targetAxis = "axisNull";

	private GameObject targetObject;

	private bool isDragging = false;

	public bool transformNow = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transformNow) {

			if (Input.touchCount > 0) {
		
				touch = Input.touches [0];
			}
			
			if (touch.phase == TouchPhase.Began) {

				ray = Camera.main.ScreenPointToRay (touch.position);


				if (Physics.Raycast (ray, out hit, Mathf.Infinity) && !IsPointerOverUIObject() && (hit.collider.tag == "Sands" || hit.collider.tag == "Model")) {
                    //
                    Vector3 axisSpawnPoint; 

					if (GO) {
				
						Destroy (GO);
					}

					targetObject = hit.collider.gameObject;	
					GO = Instantiate (transformAxis) as GameObject;
					GO.transform.SetParent (hit.transform);
					axisSpawnPoint = hit.collider.transform.localPosition;
					GO.transform.position = axisSpawnPoint;
				}
				
				if (Physics.Raycast (ray, out hit, Mathf.Infinity) && hit.collider.tag == "axisX") {

					targetAxis = "axisX";

				} else if (Physics.Raycast (ray, out hit, Mathf.Infinity) && hit.collider.tag == "axisY") {

					targetAxis = "axisY";

				} else if (Physics.Raycast (ray, out hit, Mathf.Infinity) && hit.collider.tag == "axisZ") {

					targetAxis = "axisZ";

				} else {
				}

				isDragging = true;

			}

		}


		if (touch.phase == TouchPhase.Moved && isDragging) {
			
			float distance = Vector3.Distance (Camera.main.transform.position, targetObject.transform.position);
			distance = distance * 2.0f;
			Vector3 offset = Vector3.zero;

			switch (targetAxis) {

			case("axisX"):

				Debug.Log ("axisX");
				float deltaX = Input.GetAxis ("Mouse X") * (Time.deltaTime * distance);
				offset = -Vector3.left * deltaX;
				offset = new Vector3 (offset.x * Time.deltaTime, 0.0f, 0.0f);
				targetObject.transform.Translate (offset, Space.World);
				break;

			case("axisY"):
				
				Debug.Log ("axisY");
				float deltaY = Input.GetAxis ("Mouse Y") * (Time.deltaTime * distance);
				offset = Vector3.up * deltaY;
				offset = new Vector3 (0.0f, offset.y * Time.deltaTime, 0.0f);
				targetObject.transform.Translate (offset, Space.World);
				break;

			case("axisZ"):

				Debug.Log ("axisZ");
				float deltaZ = Input.GetAxis ("Mouse Y") * (Time.deltaTime * distance);
				offset = Vector3.up * deltaZ;
				offset = new Vector3 (0.0f, 0.0f, offset.y * Time.deltaTime);
				targetObject.transform.Translate (offset, Space.World);
				break;

			default:
				break;

				
			}


//			transformAxis.transform.position = targetObject.transform.position;

		}

		if (isDragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			isDragging = false;
			targetAxis = "axisNull";
		}

		
	}


	public void StartTransform(){

		transformNow = true;
	}

	public void StopTransform(){
	
		transformNow = false;
		Destroy (GO);
	}


	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}
