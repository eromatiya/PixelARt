using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFXManager : MonoBehaviour {


	public GameObject fireFX;
	public GameObject smokeFX;

	bool isOnFire = false;
	bool isSmoking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!isOnFire || !isSmoking) {
		
			if (HealthManager.health <= 25) {

				fireFX.SetActive (true);
				isOnFire = true;
			
			} else if (HealthManager.health > 25 && HealthManager.health <= 50) {
			
				smokeFX.SetActive (true);
				isSmoking = true;

			}

		}

	}

	public void DisableDamageFX(){
	
		fireFX.SetActive (false);
		smokeFX.SetActive (false);
		isOnFire = false;
		isSmoking = false;
	
	}
}
