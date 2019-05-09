using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARScaleSlider : MonoBehaviour {


	public GameObject arMarker;
	public Slider arScaleSliderGame;
	public Slider arScaleSliderSBox;
	private float origARScale;
	private float maxValue;

	private Scene activeScene;
	private string sceneName;

	// Use this for initialization
	void Start () {

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;


		switch (sceneName) {

		case("book1Page1"):
			maxValue = 60.0f;
			break;

		case("book1Page2"):
		case("book1Page3"):
		case("book3Page2"):
			maxValue = 10.0f;
			break;

		case("book2Page1"):
		case("book2Page2"):
		case("book2Page3"):
			maxValue = 30.0f;
			break;

		case("book3Page1"):
		case("book3Page3"):
			maxValue = 60.0f;
			break;
		
		default:
			break;

		}

		arScaleSliderGame.maxValue = maxValue;
		arScaleSliderSBox.maxValue = maxValue;
		origARScale = arMarker.GetComponent<ARMarker> ().NFTScale;
		SetOrigScaleSlider (arMarker.GetComponent<ARMarker> ().NFTScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetARScale(float arScale){
	
		arMarker.GetComponent<ARMarker> ().NFTScale = maxValue - arScale;
		Debug.Log(arMarker.GetComponent<ARMarker> ().NFTScale);

	}

	public void SetOrigScaleSlider(float origScale){

		arScaleSliderGame.value = maxValue - origScale;
		arScaleSliderSBox.value = maxValue - origScale;
	}
}
