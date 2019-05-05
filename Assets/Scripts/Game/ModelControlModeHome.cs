using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModelControlModeHome : MonoBehaviour {

	//public GameObject gameTerrain;

	public Image controlImageBtn;
	public Image controlImageBtnH;
	public Sprite dPadSprite;
	public Sprite tapSprite;
	public Text controlText;
	public Text controlTextH;



	private string controlName;

	bool isPlaying = false;

	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("controlMode")) {
		
			PlayerPrefs.SetString ("controlMode", "dPad");
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


			ButtonLabel ("DPAD MODE");

			controlName = "tapMode";
			break;



		case ("tapMode"):
			controlImageBtn.GetComponent<Image> ().sprite = tapSprite;
			controlImageBtnH.GetComponent<Image> ().sprite = tapSprite;


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
		
}
