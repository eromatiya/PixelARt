using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderControl : MonoBehaviour {



	// Reference to Audio Source component
	private AudioSource audioSrc;
	public Slider slider;
	// Music volume variable that will be modifiedx
	// by dragging slider knob
	private float musicVolume = 0.5f;


	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("volumeLevel")) {

			PlayerPrefs.SetFloat ("volumeLevel", musicVolume);

		}


		slider.value = PlayerPrefs.GetFloat ("volumeLevel");

		// Assign Audio Source component to control it
		audioSrc = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

		// Setting volume option of Audio Source to be equal to musicVolume
		audioSrc.volume = musicVolume;
	}

	// Method that is called by slider game object
	// This method takes vol value passed by slider
	// and sets it as musicValue
	public void SetVolume(float vol)
	{
		musicVolume = vol;
		PlayerPrefs.SetFloat ("volumeLevel", musicVolume);
		PlayerPrefs.Save ();
	}
}


