using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollideOnObstacle : MonoBehaviour {

	GameObject expManager;


	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectWithTag ("ExplosionManager")) {

			expManager = GameObject.Find ("ExplosionManager");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider obstacle){

		if (obstacle.gameObject.tag == "Obstacle")
		{


			expManager.GetComponent<ExplosionManager> ().ExplodeSmall (transform.position);
			Destroy (gameObject);
		}


	}
}
