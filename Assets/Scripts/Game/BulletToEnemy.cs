using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToEnemy : MonoBehaviour {

	GameObject expManager;
	GameObject uiController;

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectWithTag ("ExplosionManager")) {
		
			expManager = GameObject.FindGameObjectWithTag ("ExplosionManager");
		}

		if (GameObject.FindGameObjectWithTag ("Controller")) {

			uiController = GameObject.FindGameObjectWithTag ("Controller");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider obstacle)
	{
		if (obstacle.gameObject.tag == "Obstacle")
		{
			
	
			expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
			Destroy (gameObject);
		}

		if (obstacle.gameObject.tag == "BulletEnemy") {


			expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
			ScoreScript.Score += 10.0f;
			Destroy (obstacle.gameObject);
			Destroy (gameObject);

		}

		if (obstacle.gameObject.tag == "ObstacleShip") {
			


			if (uiController.GetComponent<UserInterfaceButtons> ().oldEnemy) {
				if (obstacle.transform.gameObject != uiController.GetComponent<UserInterfaceButtons> ().oldEnemy) {

					HealthManager.enHealth = 100.0f;
				}
			}

			uiController.GetComponent<UserInterfaceButtons> ().oldEnemy = obstacle.transform.gameObject;


			uiController.GetComponent<UserInterfaceButtons> ().enemyBar.SetActive (true);
			expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
			CheckEnemyHealth (20.0f, obstacle);
			Destroy (gameObject);


		}
	}

	private void CheckEnemyHealth(float damage, Collider hit){

		HealthManager.enHealth -= damage;
		Destroy (gameObject);
		if (HealthManager.enHealth <= 0) {
		
			ScoreScript.Score += 50.0f;
			expManager.GetComponent<ExplosionManager> ().ExplodeLarge (transform.position);
			uiController.GetComponent<UserInterfaceButtons> ().enemyBar.SetActive (false);
			HealthManager.enHealth = 100.0f;
			Destroy (hit.transform.gameObject);

		}
	}

}
