using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour {

    public bool isOver = false;
    public GameObject GameOverScr;
	private AudioSource GameOverSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip GameOverSFX; 

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();
		GameOverSource.clip = GameOverSFX;
		GameOverSource.playOnAwake = false; 
		GameOverSource.volume = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.tag == "Obstacle")
        {
            
            GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing = false;
            GameOverScr.SetActive(true);
			GameOverSource.PlayOneShot (GameOverSFX);
            GameOver();
            Debug.Log("Game Over!");
            GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().SetAnimationIdle();
            GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
			if(obstacle.name.Contains("Spider")) { Destroy(obstacle.gameObject); }
        }
    }

    private void GameOver()
    {
        isOver = true;

    }
}
