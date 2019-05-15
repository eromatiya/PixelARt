using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    public GameObject explosionLarge;
	public GameObject explosionSmall;
    private AudioSource kaBoomSrc { get { return GetComponent<AudioSource>(); } }
    public AudioClip kaBoomSFX;

    // Use this for initialization
    void Start () {

        gameObject.AddComponent<AudioSource>();
        kaBoomSrc.clip = kaBoomSFX;
        kaBoomSrc.playOnAwake = false;
        kaBoomSrc.priority = 256; 
        kaBoomSrc.volume = 1.0f;


    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ExplodeSmall(Vector3 position) {

        GameObject kaBoom = Instantiate(explosionSmall, position, Quaternion.identity);
		kaBoomSrc.volume = 0.45f;
        kaBoomSrc.PlayOneShot(kaBoomSFX);

    }


	public void ExplodeLarge(Vector3 position) {

		GameObject kaBoom = Instantiate(explosionLarge, position, Quaternion.identity);
		kaBoomSrc.volume = 1.0f;
		kaBoomSrc.PlayOneShot(kaBoomSFX);

	}
}
