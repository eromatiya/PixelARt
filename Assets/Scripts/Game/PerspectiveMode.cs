using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerspectiveMode : MonoBehaviour {

	public Button perspButton;

	public ARTrackedObject arTrackedObj;

	public Sprite thirdPersonSprite;
	public Sprite firstPersonSprite;
	public Sprite defaultSprite;

	GameObject arCamera;
	GameObject arCamParent;
	GameObject model;

	public GameObject ship;

	Vector3 origARCamLocPos;
	Vector3 origARCamLocEulAngles;

	Scene activeScene;
	string sceneName;

	public string perspView = "defaultView";

	// Use this for initialization
	void Start () {

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;

		arCamera = Camera.main.gameObject;	
		arCamParent = Camera.main.transform.parent.gameObject;

		model = gameObject.GetComponent<UserInterfaceButtons> ().Model;

		origARCamLocPos = arCamera.transform.localPosition;
		origARCamLocEulAngles = arCamera.transform.localEulerAngles;

		ChangePerspective ();

	}
	
	// Update is called once per frame
	void Update () {



	}

	public void ChangePerspective(){
	
		switch (perspView) {


		case "defaultView":

			perspButton.GetComponent<Image> ().sprite = defaultSprite;

			arTrackedObj.secondsToRemainVisible = 0.0f;

			DefaultView ();

			perspView = "thirdPerson";

			break;

		case "thirdPerson":

			arTrackedObj.secondsToRemainVisible = Mathf.Infinity;

			perspButton.GetComponent<Image> ().sprite = thirdPersonSprite;

			ThirdPersonView ();

			perspView = "firstPerson";

			break;

		case "firstPerson":
			
			arTrackedObj.secondsToRemainVisible = Mathf.Infinity;

			perspButton.GetComponent<Image> ().sprite = firstPersonSprite;

			FirstPersonView ();

			perspView = "thirdPerson";

			break;
		}

	}


	private void ThirdPersonView(){

		DefaultView ();

		switch (sceneName) {

		case "book1Page1":


			Vector3 horseThirdPersonLocPosition = new Vector3 (0, -0.723f, -0.553f);
			Vector3 horseThirdPersonLocEulerAngles = new Vector3 (-68.471f, 0, 0);
	
			arCamera.transform.localPosition = horseThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = horseThirdPersonLocEulerAngles;

			break;
		
		case "book1Page2":


			Vector3 sharkThirdPersonLocPosition = new Vector3 (0, -0.83f, -0.57f);
			Vector3 sharkThirdPersonLocEulerAngles = new Vector3 (-68.471f, 0, 0);


			arCamera.transform.localPosition = sharkThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = sharkThirdPersonLocEulerAngles;

			break;

		case "book1Page3":

			Vector3 bearThirdPersonLocPosition = new Vector3 (0.51f, -0.7f, -1.2f);
			Vector3 bearThirdPersonLocEulerAngles = new Vector3 (-31.8f, 0, 0);

			arCamera.transform.localPosition = bearThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = bearThirdPersonLocEulerAngles;

			break;

		case "book2Page1":
			Vector3 ship1ThirdPersonLocPosition = new Vector3 (0, -0.472f, -0.351f);
			Vector3 ship1ThirdPersonLocEulerAngles = new Vector3 (-68.471f, 0, 0);

			arCamera.transform.localPosition = ship1ThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = ship1ThirdPersonLocEulerAngles;

			break;

		case "book2Page2":


			Vector3 ship2ThirdPersonLocPosition = new Vector3 (0, -0.725f, -0.33f);
			Vector3 ship2ThirdPersonLocEulerAngles = new Vector3 (-74.50101f, 0, 0);

			arCamera.transform.localPosition = ship2ThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = ship2ThirdPersonLocEulerAngles;

			break;

		case "book2Page3":
			Vector3 ship3ThirdPersonLocPosition = new Vector3 (0, -0.65f, -0.33f);
			Vector3 ship3ThirdPersonLocEulerAngles = new Vector3 (-74.50101f, 0, 0);

			arCamera.transform.localPosition = ship3ThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = ship3ThirdPersonLocEulerAngles;

			break;

		case "book3Page1":

			Vector3 heliThirdPersonLocPosition = new Vector3 (0, -0.684f, -0.51f);
			Vector3 heliThirdPersonLocEulerAngles = new Vector3 (-68.471f, 0, 0);


			arCamera.transform.localPosition = heliThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = heliThirdPersonLocEulerAngles;

			break;

		case "book3Page2":


			Vector3 shipThirdPersonLocPosition = new Vector3 (0.203f, -0.316f, -0.615f);
			Vector3 shipThirdPersonLocEulerAngles = new Vector3 (-30.552f, 0, 0);

			arCamera.transform.localPosition = shipThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = shipThirdPersonLocEulerAngles;
			break;

		case "book3Page3":

			Vector3 carThirdPersonLocPosition = new Vector3 (0, -0.778f, -0.54f);
			Vector3 carThirdPersonLocEulerAngles = new Vector3 (-67.471f, 0, 0);


			arCamera.transform.localPosition = carThirdPersonLocPosition;
			arCamera.transform.localEulerAngles = carThirdPersonLocEulerAngles;

			break;
		default:
			break;
		}
	
	}


	private void FirstPersonView(){

		arCamera.transform.SetParent (model.transform);

		switch (sceneName) {

		case "book1Page1":

			Vector3 horseFirstPersonLocPosition = new Vector3 (0.0f, 0.178f, 0.151f);
			Vector3 horseFirstPersonLocEulerAngles = new Vector3 (0, 0, 0);

			arCamera.transform.localPosition = horseFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = horseFirstPersonLocEulerAngles;

			break;

		case "book1Page2":
			
			Vector3 sharkFirstPersonLocPosition = new Vector3 (0.0f, 0.048f, 0.154f);
			Vector3 sharkFirstPersonLocEulerAngles = new Vector3 (0, 0, 0);
	
			arCamera.transform.localPosition = sharkFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = sharkFirstPersonLocEulerAngles;

			break;

		case "book1Page3":
			
			Vector3 bearFirstPersonLocPosition = new Vector3 (0.0f, 0.136f, 0.216f);
			Vector3 bearFirstPersonLocEulerAngles = new Vector3 (0, 0, 0);


			arCamera.transform.localPosition = bearFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = bearFirstPersonLocEulerAngles;

			break;

		case "book2Page1":
			Vector3 ship1FirstPersonLocPosition = new Vector3 (0.0f, 0.023f, 0.072f);
			Vector3 ship1FirstPersonLocEulerAngles = new Vector3 (0, 0, 0);

			arCamera.transform.SetParent (ship.transform);
			arCamera.transform.localPosition = ship1FirstPersonLocPosition;
			arCamera.transform.localEulerAngles = ship1FirstPersonLocEulerAngles;

			break;

		case "book2Page2":


			Vector3 ship2FirstPersonLocPosition = new Vector3 (0.0f, 0.06f, -0.06f);
			Vector3 ship2FirstPersonLocEulerAngles = new Vector3 (0, 0, 0);

			arCamera.transform.SetParent (ship.transform);
			arCamera.transform.localPosition = ship2FirstPersonLocPosition;
			arCamera.transform.localEulerAngles = ship2FirstPersonLocEulerAngles;

			break;

		case "book2Page3":

			arCamera.transform.SetParent (ship.transform);

			Vector3 ship3FirstPersonLocPosition = new Vector3 (-0.012f, 0.065f, -0.061f);
			Vector3 ship3FirstPersonLocEulerAngles = new Vector3 (0, 0, 0);

			arCamera.transform.localPosition = ship3FirstPersonLocPosition;
			arCamera.transform.localEulerAngles = ship3FirstPersonLocEulerAngles;

			break;

		case "book3Page1":

			Vector3 heliFirstPersonLocPosition = new Vector3 (0f, -0.155f, -0.077f);
			Vector3 heliFirstPersonLocEulerAngles = new Vector3 (90, 0, 180);


			arCamera.transform.localPosition = heliFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = heliFirstPersonLocEulerAngles;

			break;

		case "book3Page2":


			Vector3 shipFirstPersonLocPosition = new Vector3 (0f, 0.036f, 0.015f);
			Vector3 shipFirstPersonLocEulerAngles = new Vector3 (0, 0, 0);

			arCamera.transform.localPosition = shipFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = shipFirstPersonLocEulerAngles;

			break;

		case "book3Page3":
			Vector3 carFirstPersonLocPosition = new Vector3 (0f, -0.054f, -0.11f);
			Vector3 carFirstPersonLocEulerAngles = new Vector3 (90, 0, -180);

			arCamera.transform.localPosition = carFirstPersonLocPosition;
			arCamera.transform.localEulerAngles = carFirstPersonLocEulerAngles;

			break;
		default:
			break;
		}

	
	
	}

	public void DefaultView(){

		arCamera.transform.SetParent (arCamParent.transform);

	}

}
