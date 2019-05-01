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

    
    // Use this for initialization
    void Start () {
        
		playRandomSounds = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().isOnTarget;


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
        if (playRandomSounds)
        {
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
        playRandomSounds = true;
    }

    public void EnableRandomSound() {

        playRandomSounds = true;
    }


}
