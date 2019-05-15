using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitObstacle : MonoBehaviour {

    public bool isOver = false;
    public GameObject GameOverScr;
	private AudioSource GameOverSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip GameOverSFX; 

	public GameObject expManager;

	GameObject uiController;

	Scene activeScene;
	string sceneName;

	// Use this for initialization
	void Start () {

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;


		if (GameObject.FindGameObjectWithTag ("Controller")) {

			uiController = GameObject.FindGameObjectWithTag ("Controller");
		}

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
			if (obstacle.name.Contains ("Snake")) {

				HealthManager.health -= 15.0f;
				if (HealthManager.health <= 0) {

					GameIsOver ();
				}
				Destroy (obstacle.gameObject); 

			} else if (obstacle.name.Contains ("spider")) {
				
				HealthManager.health -= 15.0f;
				if (HealthManager.health <= 0) {
				
					GameIsOver ();
				}
				Destroy (obstacle.gameObject); 

			} else if (obstacle.name.Contains ("UnderSeaMine")) {


				HealthManager.health -= 20.0f;
				if (expManager) {
					expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
				}
				if (HealthManager.health <= 0) {

					GameIsOver ();
				}
				Destroy (obstacle.gameObject); 

			} else if (obstacle.name.Contains ("SeaMine")) {


				CheckHealth (25.0f);
				if (expManager) {
					expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
				}
				Destroy (obstacle.gameObject); 

			} else if (obstacle.name.Contains ("Seagul")) {


				CheckHealth (5.0f);
				if (expManager) {
					expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
				}
				Destroy (obstacle.gameObject); 

			} else if (obstacle.name.Contains ("road")) {

				CheckHealth (5.0f);

				if (expManager) {
					expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
				}
				Destroy (obstacle.gameObject); 

			} else {
			
				if (expManager && sceneName != "book1Page2") {
					expManager.GetComponent<ExplosionManager> ().ExplodeLarge (transform.position);
				}
				GameIsOver ();
			}
				
        }

		if (obstacle.gameObject.tag == "BulletEnemy") {
		
			expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
			CheckHealth (25.0f);
			Destroy (obstacle.gameObject);
		
		}

		if (obstacle.gameObject.tag == "ObstacleShip") {

			expManager.GetComponent<ExplosionManager> ().ExplodeLarge (transform.position);
			HealthManager.enHealth = 100.0f;
			uiController.GetComponent<UserInterfaceButtons> ().enemyBar.SetActive (false);
			CheckHealth (50.0f);
			Destroy (obstacle.gameObject);

		}
    }

	private void CheckHealth(float damage){
	

		HealthManager.health -= damage;
		if (HealthManager.health <= 0) {

			expManager.GetComponent<ExplosionManager> ().ExplodeLarge (transform.position);
			GameIsOver ();
		}

	}

    private void GameOver()
    {
        isOver = true;

    }

	private void GameIsOver(){
	
		GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing = false;
		GameOverScr.SetActive(true);
		GameOverSource.PlayOneShot (GameOverSFX);
		GameOver();
		Debug.Log("Game Over!");
		GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().SetAnimationIdle();
		GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();

	}
}
