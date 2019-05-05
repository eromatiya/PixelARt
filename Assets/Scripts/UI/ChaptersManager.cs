using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChaptersManager : MonoBehaviour {

	public GameObject secretPanel;
	private Animator secretPanAnim;
	private CanvasGroup secretPanCanGroup;

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

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}


}
