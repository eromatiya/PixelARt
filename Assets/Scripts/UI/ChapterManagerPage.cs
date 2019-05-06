using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManagerPage : MonoBehaviour {

	public Button chapter2Btn;
	public Button chapter3Btn;


	//Normal text
	public Text chapter2Txt;
	public Text chapter2HTxt;

	//Highlight text
	public Text chapter3Txt;
	public Text chapter3HTxt;

	private float totalStars;

	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("starTotal")) {

			PlayerPrefs.SetInt ("starTotal", 0);

		}

		totalStars = PlayerPrefs.GetInt ("starTotal");

		StarChecker ();


	}

	// Update is called once per frame
	void Update () {
	}

	private void StarChecker(){

		if (totalStars >= 750) {

			Chapter2UI ("CHAPTER 2", true);
			Chapter3UI ("CHAPTER 3", true);

		} else if (totalStars >= 500 && totalStars < 750) {


			Chapter2UI ("CHAPTER 2", true);
			Chapter3UI ("LOCKED", false);

		} else {

			Chapter2UI ("LOCKED", false);
			Chapter3UI ("LOCKED", false);
		}



	}


	private void Chapter2UI(string status, bool interact){

		chapter2Btn.interactable = interact;
		chapter2Txt.text = status;
		chapter2HTxt.text = status;

	}

	private void Chapter3UI(string status, bool interact){

		chapter3Btn.interactable = interact;
		chapter3Txt.text = status;
		chapter3HTxt.text = status;

	}

}
