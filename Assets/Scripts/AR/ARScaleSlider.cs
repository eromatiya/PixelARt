using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARScaleSlider : MonoBehaviour {


	public GameObject arMarker;
	public Slider arScaleSliderGame;
	public Slider arScaleSliderSBox;
	private float origARScale;
	private float maxValue;

	// Use this for initialization
	void Start () {

		maxValue = 60.0f;
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
