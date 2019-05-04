using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


using UnityEngine;
using System.Collections;
 
public class TapToMove : MonoBehaviour {
	 
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;

	Scene activeScene;
	string sceneName;

	public bool isTouchMode = false;

	string currentAnimation = "";

	public bool enableLoop = false;


	GameObject stopButtonClone;

	void Start(){

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;

		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;

		stopButtonClone = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().StopGame;
	}
	 
	 // Update is called once per frame
	void Update () {
	 
		if (isTouchMode && !IsPointerOverUIObject() && stopButtonClone.activeSelf) {

			//check if the screen is touched / clicked   
			if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (0))) {
				//declare a variable of RaycastHit struct
				RaycastHit hit;
				//Create a Ray on the tapped / clicked position
				Ray ray;
				//for unity editor
				#if UNITY_EDITOR
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//for touch device
				#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
		  		 ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				#endif
		 
				//Check if the ray hits any collider
				if (Physics.Raycast (ray, out hit)) {
					//set a flag to indicate to move the gameobject
					flag = true;
					//save the click / tap position
					endPoint = hit.point;
					//as we do not want to change the y axis value based on touch position, reset it to original y axis value
					endPoint.y = yAxis;
					Debug.Log (endPoint);
				}
		    
			}
			//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
			if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) { //&& !(V3Equal(transform.position, endPoint))){
				//move the gameobject to the desired position
		   
				gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
				//In the above line of code, we are basically moving the gameobject to the touched / clicked position at a constant speed. 
				//The first argument in the Lerp function is the source, 
				//second is the destination and third is the amount of time it should take to reach the destination from the source. 
				//Greater the duration value, lesser the speed, and vice versa.
				//We have also multiplied the distance between the source and destination to this duration to make sure that the speed remains constant regardless of the distance between the two points. 
				//(NOTE: Try removing Vector3.Distance(gameObject.transform.position, endPoint) and see how the speed is non uniform, but reaches the destination in a same time regardless of the distance between start point and end point)

				//face the desired location
				gameObject.transform.LookAt (endPoint);

				//Enable animation/sound fx
				if (sceneName == "book1Page3" && !enableLoop)
				{
					SetAnimation("isWalking");
					GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().PlayLoopSound();
					enableLoop = true;
				}

			}
		
			//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		
			else if (flag && Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {


				if (sceneName == "book1Page3" && enableLoop)
				{
					SetAnimationIdle();
					GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
					enableLoop = false;
				}

				flag = false;
				Debug.Log ("I am here");
		
			}
		   
		}
	}


	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}


	private void SetAnimation(string animationName)
	{

		if (currentAnimation != "")
		{
			this.GetComponent<Animator>().SetBool(currentAnimation, false);
		}
		this.GetComponent<Animator>().SetBool(animationName, true);
		currentAnimation = animationName;
	}

	private void SetAnimationIdle()
	{

		if (currentAnimation != "")
		{
			this.GetComponent<Animator>().SetBool(currentAnimation, false);
		}
	}


	private void OnTriggerEnter(Collider obstacle)
	{
		if (obstacle.gameObject.tag == "GameWall")
		{

			StopOnCollide ();
		}
	}


	public void StopOnCollide(){

		SetAnimationIdle ();
		GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
		enableLoop = false;
		flag = false;
	}

}



























/*
public class TapToMove : MonoBehaviour {
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;

	public bool isTouch = false;

	private bool isPlaying;

	

	string currentAnimation = "";

	private string sceneName;
	private Scene activeScene;

	void Start(){
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;


		activeScene = SceneManager.GetActiveScene();
		sceneName = activeScene.name;
	}

	// Update is called once per frame
	void Update () {

		if (isTouch) {

			isPlaying = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().Playing;

			if (isPlaying) {
				//check if the screen is touched / clicked   
				if ((!IsPointerOverUIObject() && (Input.touchCount > 0 && (Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (0))))) {
					//declare a variable of RaycastHit struct
					RaycastHit hit;
					//Create a Ray on the tapped / clicked position
					Ray ray;
					//for unity editor
					#if UNITY_EDITOR
						ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					//for touch device
					#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
						ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					#endif

					//Check if the ray hits any collider
					if (Physics.Raycast (ray, out hit)) {
						//set a flag to indicate to move the gameobject
						flag = true;
						//save the click / tap position
						endPoint = hit.point;
						//as we do not want to change the y axis value based on touch position, reset it to original y axis value
						endPoint.y = yAxis;
						Debug.Log (endPoint);
					}

				}
				//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
				if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) { //&& !(V3Equal(transform.position, endPoint))){
					//move the gameobject to the desired position
					gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
					//In the above line of code, we are basically moving the gameobject to the touched / clicked position at a constant speed. 
					//The first argument in the Lerp function is the source, 
					//second is the destination and third is the amount of time it should take to reach the destination from the source. 
					//Greater the duration value, lesser the speed, and vice versa.
					//We have also multiplied the distance between the source and destination to this duration to make sure that the speed remains constant regardless of the distance between the two points. 
					//(NOTE: Try removing Vector3.Distance(gameObject.transform.position, endPoint) and see how the speed is non uniform, but reaches the destination in a same time regardless of the distance between start point and end point)


					//face the desired location
					gameObject.transform.LookAt (endPoint);

					

					if (sceneName == "book3Page2" && !enableLoop)
					{
						GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().PlayLoopSound();
						enableLoop = true;
					}

				}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if (flag && Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
					flag = false;

					if (sceneName == "book3Page2" && enableLoop)
					{

						GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
						enableLoop = false;
					}

					Debug.Log ("I am here");
				}

			}
		}
	}








} 


*/