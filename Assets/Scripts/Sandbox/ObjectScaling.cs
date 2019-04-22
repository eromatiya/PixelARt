using UnityEngine;
using System.Collections;
public class ObjectScaling : MonoBehaviour {

	private GameObject selectedObject;   
	public bool scaleMode = false;

	void Update () {


		if (scaleMode) {

			//I WANNA SLEEP
			if (Input.touchCount == 1) {
				Touch touch = Input.touches [0];
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100f) && (hit.collider.tag == "Sands" || hit.collider.tag == "Model")) {
					selectedObject = hit.collider.gameObject;
				}
			}
			if (Input.touchCount == 2) {
				// Store both touches.
				Touch touchZero = Input.GetTouch (0);
				Touch touchOne = Input.GetTouch (1);

				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				// Find the difference in distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

							
				Vector3 newScale = selectedObject.transform.localScale - new Vector3 (deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f);
				selectedObject.transform.localScale = newScale;
				
			}
		}
	}

	public void StartScaling(){

		scaleMode = true;

	}
	public void StopScaling(){

		scaleMode = false;
	}

}