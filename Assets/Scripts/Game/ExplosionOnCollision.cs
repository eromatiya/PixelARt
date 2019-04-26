using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnCollision : MonoBehaviour {

    public GameObject explosion;
    private AudioSource kaBoomSrc { get { return GetComponent<AudioSource>(); } }
    public AudioClip kaBoomSFX;

    // Use this for initialization
    void Start () {

        gameObject.AddComponent<AudioSource>();
        kaBoomSrc.clip = kaBoomSFX;
        kaBoomSrc.playOnAwake = false;
        kaBoomSrc.volume = 1.0f;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.tag == "Obstacle")
        {
            Destroy(obstacle.gameObject);
            Explode();
        }
    }

    void Explode() {

        GameObject kaBoom = Instantiate(explosion, transform.position, Quaternion.identity);
        kaBoomSrc.PlayOneShot(kaBoomSFX);

    }
}
