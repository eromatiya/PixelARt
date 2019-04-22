using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeControl : MonoBehaviour {

	public GameObject plane;
	public GameObject SpawnIt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void onSpawn(){

		if (!gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().StartOutline ();
		}

		if (!SpawnIt.GetComponent<SpawnIt> ().spawnMode) {
			SpawnIt.GetComponent<SpawnIt> ().IsSpawning ();
		}

		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}

		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}

		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}


		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);
		}	
	}

	public void onClone(){

		if (!SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOn ();
		}


		if (!gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().StartOutline ();
		}

		if (SpawnIt.GetComponent<SpawnIt> ().spawnMode) {
			SpawnIt.GetComponent<SpawnIt> ().DefaultMode ();
		}

		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}

		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}

		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);	
		}
	}

	public void onDelete(){
		
		if (gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().NormalOutline ();
		}


		if (!SpawnIt.GetComponent<SpawnIt> ().deleteMode) {
			SpawnIt.GetComponent<SpawnIt> ().IsDeleting ();
		}

		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}

		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}


		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}

		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);
		}	
	}

	public void onDrag(){
		
		if (!gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().StartOutline ();
		}

		if (SpawnIt.GetComponent<SpawnIt> ().spawnMode || SpawnIt.GetComponent<SpawnIt> ().deleteMode) {
			SpawnIt.GetComponent<SpawnIt> ().DefaultMode ();
		}

		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}


		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}

		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (!gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StartTransform ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);
		}
	}

	public void onRotate(){

		if (!gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().StartOutline ();
		}

		if (SpawnIt.GetComponent<SpawnIt> ().spawnMode || SpawnIt.GetComponent<SpawnIt> ().deleteMode) {
			SpawnIt.GetComponent<SpawnIt> ().DefaultMode ();
		}

		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}

		if (!gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOn ();
		}

		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}


		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);
		}
	}

	public void onScale(){

		if (!gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().StartOutline ();
		}

		if (SpawnIt.GetComponent<SpawnIt> ().spawnMode || SpawnIt.GetComponent<SpawnIt> ().deleteMode) {
			SpawnIt.GetComponent<SpawnIt> ().DefaultMode ();
		}

		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}


		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}

		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}

		if (!gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StartScaling ();
		}

		if (!plane.activeSelf) {
			plane.SetActive (true);
		}
	}

	public void onOK(){
		
		if (gameObject.GetComponent<ActiveOutline> ().activateOutline) {
			gameObject.GetComponent<ActiveOutline> ().NormalOutline ();
		}

		if (SpawnIt.GetComponent<SpawnIt> ().spawnMode || SpawnIt.GetComponent<SpawnIt> ().deleteMode) {
			SpawnIt.GetComponent<SpawnIt> ().DefaultMode ();
		}

		if (gameObject.GetComponent<RotateObj> ().rotateMode) {
			gameObject.GetComponent<RotateObj> ().modeRotateOff ();
		}


		if (SpawnIt.GetComponent<CloneIt> ().toggleClone) {
			SpawnIt.GetComponent<CloneIt> ().cloneToggleOff ();
		}

		if (gameObject.GetComponent<DragOnAxis> ().transformNow) {
			gameObject.GetComponent<DragOnAxis> ().StopTransform ();
		}

		if (gameObject.GetComponent<ObjectScaling> ().scaleMode) {
			gameObject.GetComponent<ObjectScaling> ().StopScaling ();
		}

		if (plane.activeSelf) {
			plane.SetActive (false);
		}	
	}


}
