using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    int sysHour = System.DateTime.Now.Hour;
    private AudioSource backgroundMusic;
    public AudioClip horrorClip;
    // Use this for initialization
    void Start () {

        if (sysHour == 0)
        {
            //night
            backgroundMusic = gameObject.GetComponent<AudioSource>();
            backgroundMusic.clip = horrorClip;
            backgroundMusic.Play();

        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted",0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);

        }
    }
}
