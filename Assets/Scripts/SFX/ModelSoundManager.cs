using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelSoundManager : MonoBehaviour {


    private AudioSource randomSound;
    private AudioSource loopSound;

    public AudioClip[] audioSources;

    public AudioClip loopSource;

    private bool playRandomSounds = false;
	private bool isOnMarker;

    
    // Use this for initialization
    void Start () {
        


        CallAudio();


	}
	
	// Update is called once per frame
	void Update () {
             		
	}


    public void CallAudio()
    {

        InvokeRepeating("PlayRandomSFX", 5, Random.Range(5,10));
    }


    public void PlayRandomSFX()
    {
		Debug.Log ("Play random false");
        if (playRandomSounds == true)
        {
			Debug.Log ("Play Random true");
            randomSound = gameObject.GetComponent<AudioSource>();
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
            randomSound.loop = false;
            //CallAudio();
        }
    }

    public void PlayLoopSound() {
              
            playRandomSounds = false;
            loopSound = gameObject.GetComponent<AudioSource>();
            loopSound.clip = loopSource;
            loopSound.loop = true;
            loopSound.Play();

    }

    public void StopAllSFX() {


        playRandomSounds = false;

        if(randomSound) randomSound.Stop();
        
        if(loopSound) loopSound.Stop();
        

    }


    public void StopLoopSound() {

        if(loopSound) loopSound.Stop();

		isOnMarker = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().isOnTarget;

		if (isOnMarker) {
			playRandomSounds = true;
		}
    }

    public void EnableRandomSound() {

        playRandomSounds = true;
    }


}
