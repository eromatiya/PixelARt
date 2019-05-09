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

	public GameObject arScalerSlider;
	private RectTransform newARScalerRect;

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

		GetOrigRectTransfSlider ();

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

		SetOrigRectTransfSlider ();

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

		ChangeRectTransfSlider ();

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

	private void GetOrigRectTransfSlider(){

		newARScalerRect = arScalerSlider.GetComponent<RectTransform> ();
	}

	private void SetOrigRectTransfSlider(){
	
		arScalerSlider.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (25f, 13.1f);
		arScalerSlider.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0.5f);
		arScalerSlider.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0.5f);;
		arScalerSlider.GetComponent<RectTransform> ().pivot = new Vector2 (0.5f, 0.5f);
		arScalerSlider.GetComponent<RectTransform> ().localEulerAngles = new Vector3 (0, 0, 90f);
		arScalerSlider.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		arScalerSlider.GetComponent<RectTransform> ().sizeDelta = new Vector2 (209f, 26.2f);
	}

	private void ChangeRectTransfSlider(){
	
		newARScalerRect.anchoredPosition = new Vector2 (32f, -44f);
		newARScalerRect.anchorMin = new Vector2 (0, 0.5f);
		newARScalerRect.anchorMax = new Vector2 (0, 0.5f);
		newARScalerRect.pivot = new Vector2 (0.5f, 0.5f);
		newARScalerRect.localEulerAngles = new Vector3 (0.0f, 0.0f, 90.0f);
		newARScalerRect.localScale = new Vector3 (1, 1, 1);
		newARScalerRect.sizeDelta = new Vector2 (295.6f,37.1f);

	}
}
