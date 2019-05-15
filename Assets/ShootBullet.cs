using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootBullet : MonoBehaviour {

	public GameObject bullet;
	public Button fireButton;

	private AudioSource shootSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip shootClip; 

	private Scene activeScene;
	private string sceneName;

	// Use this for initialization
	void Start () {

		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;

		gameObject.AddComponent<AudioSource>();
		shootSource.clip = shootClip;
		shootSource.playOnAwake = false;
		shootSource.priority = 256; 
		shootSource.volume = 1f;

		fireButton.onClick.AddListener (OnButtonDown);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnButtonDown(){
		//GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().Playing
		if (true) {
			shootSource.PlayOneShot (shootClip);

			Vector3 modelPos;

			GameObject bulletIns = Instantiate (bullet) as GameObject;
			Rigidbody rb = bulletIns.GetComponent<Rigidbody> ();
			modelPos = gameObject.transform.localPosition;
			bulletIns.transform.SetParent (transform);

			switch (sceneName) {

			case "book2Page1":
				bulletIns.transform.localPosition = new Vector3 (0.0f, -0.0139f, -0.05f);
				break;

			case "book2Page2":
				bulletIns.transform.localPosition = new Vector3 (0.0f, -0.0139f, -0.05f);
				break;

			case "book2Page3":
				bulletIns.transform.localPosition = new Vector3 (0.0f, -0.0139f, -0.05f);
				break;

			default:
				break;
			}

			rb.AddForce (-transform.up * 200f);
			Destroy (bulletIns, 1.15f);
		}
	}
}
