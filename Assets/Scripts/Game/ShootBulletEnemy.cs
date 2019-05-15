using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootBulletEnemy : MonoBehaviour {

	public GameObject enemyBullet;

	private AudioSource shootSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip shootClip; 
	bool Play;

	private Scene activeScene;
	private string sceneName;
	// Use this for initialization
	void Start () {


		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;


		gameObject.AddComponent<AudioSource>();
		shootSource.clip = shootClip;
		shootSource.playOnAwake = false;
		shootSource.priority = 128; 
		shootSource.volume = 0.50f;
	
		StartCoroutine ("ShootTheModel");
	}
	
	// Update is called once per frame
	void Update () {
		Play = GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing;
	}

	IEnumerator ShootTheModel(){

		while (true) {
		

			yield return new WaitForSeconds (Random.Range (0.5f, 1.0f));

			if (Play) {
				shootSource.PlayOneShot (shootClip);

				Vector3 enemyPos;

				GameObject bulletIns = Instantiate (enemyBullet) as GameObject;
				Rigidbody rb = bulletIns.GetComponent<Rigidbody> ();
				enemyPos = transform.localPosition;
				bulletIns.transform.SetParent (transform);


				switch (sceneName) {

				case "book2Page1":
					bulletIns.transform.localPosition = new Vector3 (enemyPos.x, -5f, 62f);
					break;

				case "book2Page2":
					bulletIns.transform.localPosition = new Vector3 (enemyPos.x, -1.2f, 30f);
					break;
				case "book2Page3":
					
					//bulletIns.transform.localPosition = new Vector3 (enemyPos.x, -5f, 62f);

					if (gameObject.name == "EnemyParent4") {
						
						bulletIns.transform.localPosition = new Vector3 (enemyPos.x, -12.1f, 62f);

					} else if (gameObject.name == "SharkParent") {
						
						bulletIns.transform.localPosition = new Vector3 (0, -0.047f, 0.5f);
					
					} else {
					
						bulletIns.transform.localPosition = new Vector3 (enemyPos.x, -12.8f, 30f);

					}

					break;

				default:
					break;
				}
				bulletIns.transform.SetParent (transform.root);
				rb.AddForce (transform.forward * 215);
				Destroy (bulletIns, 1);
			}
		}
	}


}
