using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnIt : MonoBehaviour {

	public GameObject[] spawnThis;
	public bool spawnMode = false;
	public bool deleteMode = false;
	private int inventoryNumber = 0;
	private GameObject GO;

	//public transform targetObject;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {



		Plane targetPlane = new Plane(transform.up, transform.position);

		foreach (Touch touch in Input.touches)
		{


			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				if (spawnMode) {
					
					Ray ray = Camera.main.ScreenPointToRay (touch.position);

					Vector3 prefabScale;
					prefabScale = spawnThis [inventoryNumber].transform.localScale;

					float dist = 0.0f;
					targetPlane.Raycast (ray, out dist);
					Vector3 planePoint = ray.GetPoint (dist);

					if (!IsPointerOverUIObject()) {
						GO = Instantiate (spawnThis[inventoryNumber]) as GameObject;
						GO.transform.SetParent (transform);
						GO.transform.localScale = prefabScale;
						GO.transform.position = planePoint;
					}


				} 


				if (deleteMode) {

					Ray rayDelete = Camera.main.ScreenPointToRay (touch.position);
					RaycastHit hit;

					float dist = 0.0f;
					targetPlane.Raycast (rayDelete, out dist);
					Vector3 planePoint = rayDelete.GetPoint (dist);

					if (Physics.Raycast (rayDelete, out hit)) {


						if (hit.collider.gameObject.tag == "Sands" || hit.collider.gameObject.tag == "SandsTerrain") {
							
							if (!IsPointerOverUIObject ()) {
								Destroy (hit.collider.gameObject);
							}
						}

					}

				}

			}
		}
	}


	public void IsDeleting(){

		deleteMode = true;
		spawnMode = false;

	}

	public void IsSpawning(){

		spawnMode = true;
		deleteMode = false;

	}

	public void DefaultMode(){

		spawnMode = false;
		deleteMode = false;


	}


	//THIS FUNCITON IS ATTACHED TO THE INVENTORY BUTTONS
	public void GetInventoryNum(int invNum){


		inventoryNumber = invNum;

	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}

	public void HideGenSandbox(){

		if (GO != null) {
			gameObject.SetActive (false);
		}
	}

	public void ShowGenSandbox(){
		if (GO != null) {
			gameObject.SetActive (true);
		}
	}
}