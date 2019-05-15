using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public Image healthBar;
	float maxHealth = 100.0f;
	public static float health;

	public Image enHealthBar;
	float enMaxHealth = 100.0f;
	public static float enHealth;

	// Use this for initialization
	void Start () {

		//healthBar = healthBar.GetComponent<Image> ();
		health = maxHealth;

		//enHealthBar = enHealthBar.GetComponent<Image> ();
		enHealth = enMaxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

		healthBar.fillAmount = health / maxHealth;

		if (gameObject.GetComponent<UserInterfaceButtons> ().enemyBar) {
			enHealthBar.fillAmount = enHealth / enMaxHealth;
		}

	}
}
