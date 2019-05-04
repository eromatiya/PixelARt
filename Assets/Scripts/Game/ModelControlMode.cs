using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModelControlMode : MonoBehaviour {

	//public GameObject gameTerrain;

	public GameObject model;
	public GameObject gamePad;
	public GameObject gameTerrain;

	public Image controlImageBtn;
	public Image controlImageBtnH;
	public Sprite dPadSprite;
	public Sprite tapSprite;
	public Text controlText;
	public Text controlTextH;

	private bool isRunningGame;
	private GameObject StopBtnClone;

	Scene activeScene;
	string sceneName;


	private string controlName;

	bool isPlaying = false;

	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("controlMode")) {
		
			PlayerPrefs.SetString ("controlMode", "dPad");
		}

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;

		StopBtnClone = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().StopGame;

		if (sceneName != "book1Page3" && sceneName != "book3Page2") {

			isRunningGame = true;

		} else {
		
			isRunningGame = false;
		}

		controlName = PlayerPrefs.GetString ("controlMode");
		controlIcon ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ControlMode(){
	
	
		PlayerPrefs.SetString ("controlMode", controlName);
		controlIcon ();
	}

	private void controlIcon(){

		switch (controlName) {



		case("dPad"):
			controlImageBtn.GetComponent<Image> ().sprite = dPadSprite;
			controlImageBtnH.GetComponent<Image> ().sprite = dPadSprite;

			//Sets the model control type to DPAD MODE
			DPadMode();


			ButtonLabel ("DPAD MODE");

			controlName = "tapMode";
			break;



		case ("tapMode"):
			controlImageBtn.GetComponent<Image> ().sprite = tapSprite;
			controlImageBtnH.GetComponent<Image> ().sprite = tapSprite;

			//Sets the model control type to tapMode
			TouchMode();


			ButtonLabel ("TAP MODE");

			controlName = "dPad";
			break;

		default:
			break;

		}

	}

	private void ButtonLabel(string label){
	
		controlText.GetComponent<Text> ().text = label;
		controlTextH.GetComponent<Text> ().text = label;
	}





	private void DPadMode(){
	
		//INFINITE RUNNING GAME
		if (isRunningGame) {

			model.GetComponent<ModelMove> ().isTouchMode = false;

			if (!gamePad.activeSelf && StopBtnClone.activeSelf) {
			
				gamePad.SetActive (true);
			}

		} else {
		
			//GAME ARENA MODE

			model.GetComponent<TapToMove> ().isTouchMode = false;
		
			if (!gamePad.activeSelf && StopBtnClone.activeSelf) {

				gamePad.SetActive (true);
			}
		
			ToggleTerrainData (false);
		}


	}


	private void TouchMode(){

		//INFINITE RUNNING GAME
		if (isRunningGame) {
			
			model.GetComponent<ModelMove> ().isTouchMode = true;

			if (gamePad.activeSelf) {
			
				gamePad.SetActive (false);
			}


		} else {
		
			//GAME ARENA MODE
		
			model.GetComponent<TapToMove> ().isTouchMode = true;

			if (gamePad.activeSelf) {

				gamePad.SetActive (false);
			}	

			ToggleTerrainData (true);
		}


	}



	public void CheckControlMode(){

		if (PlayerPrefs.GetString ("controlMode") == "dPad") {
		
			DPadMode ();

		} else {
		
			TouchMode ();
		}

	}


	private void ToggleTerrainData(bool toggle){

		if (gameTerrain) {
			gameTerrain.GetComponent<TerrainCollider> ().enabled = toggle;
		}
	}
}
