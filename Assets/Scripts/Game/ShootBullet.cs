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

	UserInterfaceButtons uicontroller;

	private float bullets = 25f;
	bool isEmpty = false;
	bool willNotShoot = false;

	// Use this for initialization
	void Start () {

		uicontroller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ();

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
		
		fireButton.GetComponent<Image> ().fillAmount += 1 / bullets * (Time.deltaTime * 1.75f);

		if (fireButton.GetComponent<Image> ().fillAmount >= 0.03999978) {

		
			willNotShoot = false;

		}

		if (fireButton.GetComponent<Image> ().fillAmount == 1) {
			
			isEmpty = false;
			
		}
	}

	void OnButtonDown(){
		
		if (uicontroller.Playing && !willNotShoot) {
			shootSource.PlayOneShot (shootClip);

			Vector3 modelPos;

			GameObject bulletIns = Instantiate (bullet) as GameObject;
			Rigidbody rb = bulletIns.GetComponent<Rigidbody> ();
			modelPos = gameObject.transform.localPosition;
			bulletIns.transform.SetParent (transform);

			switch (sceneName) {

			case "book2Page1":
				bulletIns.transform.localPosition = new Vector3 (0.0f, -0.01309f, -0.0395f);
				break;

			case "book2Page2":
				bulletIns.transform.localPosition = new Vector3 (0.007f, -0.0139f, -0.05f);
				break;

			case "book2Page3":
				bulletIns.transform.localPosition = new Vector3 (0.0085f, -0.0139f, -0.05f);
				break;

			default:
				break;
			}

			fireButton.GetComponent<Image> ().fillAmount -= 1 / bullets;
			if (fireButton.GetComponent<Image> ().fillAmount <= 0.031) {
			
				isEmpty = true;
				willNotShoot = true;
			}

			bulletIns.transform.SetParent (transform.root);
			rb.AddForce (-transform.up * 200f);
			Destroy (bulletIns, 1f);
		}
	}
}
