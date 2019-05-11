using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayTime : MonoBehaviour {

	int sysHour = System.DateTime.Now.Hour;

	public Camera mainCamera;
	public Light light;
	public GameObject fireFX;
	public GameObject fireflies;


	private Color nightSky = new Color(37f/255f,37f/255f,37f/255f,255f/255f);
	private Color daySky = new Color(143f/255f,245f/255f,255f/255f,255f/255f);
	private Color midnightSky = new Color (135f / 255f, 0f / 255f, 16f / 255f, 255f / 255f);
    private Color afternoonSky = new Color(255f / 255f, 181f / 255f, 47f / 255f, 255f / 255f);

    private Color ambientNight = new Color(57f / 255f, 57f / 255f, 57f / 255f, 255f / 255f);
    private Color ambientDay = new Color(152f / 255f, 152f / 255f, 152f / 255f, 255f / 255f);

    public GameObject horse;
	public GameObject bear;
	public GameObject spider;
	public GameObject bloodRain;
	public GameObject skull;
	public GameObject lightSign;

	string currentAnimation="";

	// Use this for initialization
	void Start () {
		
		checkTime ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//check time then execute
	private void checkTime(){
	
		if (sysHour >= 19 || (sysHour < 6 && sysHour > 0)) {
			//night
			mainCamera.backgroundColor = nightSky;
			light.intensity = 0.075f;
			fireFX.SetActive (true);
			bear.SetActive (false);
			lightSign.SetActive (true);
			fireflies.SetActive (true);
            RenderSettings.ambientLight = nightSky;

        }

        else if (sysHour == 0)
        {

            //midnight
            lightSign.SetActive(true);
            lightSign.GetComponent<Light>().color = midnightSky;
            RenderSettings.ambientLight = Color.black;
            bear.SetActive(false);
            skull.SetActive(true);
            mainCamera.backgroundColor = midnightSky;
            spider.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spider.transform.localPosition = new Vector3(0.773f, 0, 0.642f);
            fireFX.SetActive(true);
            bloodRain.SetActive(true);
            light.intensity = 5.0f;
            light.color = midnightSky;
            animHorse("isDead");
            animSpider("isAttacking");

        }
        else if (sysHour >= 17 && sysHour <= 18) {

            //afternoon
            mainCamera.backgroundColor = afternoonSky;
            light.intensity = 0.4f;
            fireFX.SetActive(true);
            bear.SetActive(false);
            lightSign.SetActive(true);
            fireflies.SetActive(true);
            RenderSettings.ambientLight = afternoonSky;

        }

        else {
			//day
			mainCamera.backgroundColor = daySky;
			light.intensity = 2.0f;
			fireFX.SetActive (false);
            RenderSettings.ambientLight = ambientDay;

		}


	
	
	}

	public void animHorse(string animationName){

		if (currentAnimation != "") {
			horse.GetComponent<Animator> ().SetBool (currentAnimation, false);
		}
		horse.GetComponent<Animator> ().SetBool (animationName, true);
		currentAnimation = animationName;
	}

	public void animSpider(string animationName){

		if (currentAnimation != "") {
			spider.GetComponent<Animator> ().SetBool (currentAnimation, false);
		}
		spider.GetComponent<Animator> ().SetBool (animationName, true);
		currentAnimation = animationName;
	}

}
