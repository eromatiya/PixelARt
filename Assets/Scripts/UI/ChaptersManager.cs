using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChaptersManager : MonoBehaviour {

	public GameObject secretPanel;
	Animator secretPanAnim;
	CanvasGroup secretPanCanGroup;

	public Button chapter2Btn;
	public Button chapter3Btn;


	//Normal text
	public Text chapter2Txt;
	public Text chapter2HTxt;

	//Highlight text
	public Text chapter3Txt;
	public Text chapter3HTxt;

	private float totalStars;

	private float unlockIn = 7;
	private int doUnlock;

	// Use this for initialization
	void Start () {
		
		if (!PlayerPrefs.HasKey ("starTotal")) {

			PlayerPrefs.SetInt ("starTotal", 0);

		}

		if (!PlayerPrefs.HasKey ("doUnlock")) {
		
			PlayerPrefs.SetInt ("doUnlock", 0);
		}

		secretPanAnim = secretPanel.GetComponent<Animator>();
		secretPanCanGroup = secretPanel.GetComponent<CanvasGroup>();

		totalStars = PlayerPrefs.GetInt ("starTotal");
		doUnlock = PlayerPrefs.GetInt ("doUnlock");
		StarChecker ();

		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
		
			
			
				if (hit.collider.tag == "ChapterUnlocker" && touch.phase == TouchPhase.Began)
				{

					unlockIn--;
					Debug.Log ("hit");
					if (unlockIn == 0 && doUnlock == 0) {
					
						Debug.Log ("Your collected star is now set to 9999!");
						PlayerPrefs.SetInt ("starTotal", 9999);
						PlayerPrefs.SetInt ("doUnlock", 1);
						totalStars = PlayerPrefs.GetInt ("starTotal");
						StarChecker ();


						secretPanAnim.Play ("Panel In");

					}
				}
			
			
			}
		
		}

	}

	private void StarChecker(){
	
		if (totalStars >= 750) {

			chapter2Btn.interactable = true;
			chapter2Txt.text = "CHAPTER 2";
			chapter2HTxt.text = "CHAPTER 2";

			chapter3Btn.interactable = true;
			chapter3Txt.text = "CHAPTER 3";
			chapter3HTxt.text = "CHAPTER 3";

		} else if (totalStars >= 500 && totalStars < 750) {

			chapter2Btn.interactable = true;
			chapter2Txt.text = "CHAPTER 2";
			chapter2HTxt.text = "CHAPTER 2";


			chapter3Btn.interactable = false;
			chapter3Txt.text = "LOCKED";
			chapter3HTxt.text = "LOCKED";

		} else {

			chapter3Btn.interactable = false;
			chapter3Txt.text = "LOCKED";
			chapter3HTxt.text = "LOCKED";
			chapter2Btn.interactable = false;
			chapter2Txt.text = "LOCKED";
			chapter2HTxt.text = "LOCKED";
		}



	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}


}
