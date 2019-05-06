using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;


public class GraphicsScript : MonoBehaviour {

	private Terrain terrainObj;

	//icon
	public Image grapLowBtn;
	public Image grapLowHBtn;
	public Image grapMedBtn;
	public Image grapMedHBtn;
	public Image grapHighBtn;
	public Image grapHighHBtn;


	//sprite/image from project panel
	public Sprite grapLSprite;
	public Sprite grapMSprite;
	public Sprite GrapHSprite;

	//text
	public Text grapStat;
	public Text grapStatH;

	private string graphicsSett;


	Scene activeScene;
	string sceneName;

	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("GraphicsMode")) {

			PlayerPrefs.SetString ("GraphicsMode", "Low");

		}


		if (GameObject.FindObjectOfType<Terrain> ()) {
			terrainObj = GameObject.FindObjectOfType<Terrain> ();
		}




		graphicsSett = PlayerPrefs.GetString ("GraphicsMode");	
		GraphicsIcon ();



		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;



	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateGraphics()
	{

		PlayerPrefs.SetString ("GraphicsMode", graphicsSett);
		GraphicsIcon ();


	}

	private void GraphicsIcon(){

		switch (graphicsSett) {

		case("Low"):

			//change buttons's icon
			grapLowBtn.GetComponent<Image> ().sprite = grapLSprite;
			grapLowHBtn.GetComponent<Image> ().sprite = grapLSprite;

			//change button's label
			buttonLabel ("POTATO");


			//change toggle grass
			//terrainObj.drawTreesAndFoliage = false;
			enableGrass (false);

			//change graphics level
			//QualitySettings.SetQualityLevel(1);
			QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.shadowDistance = 80.0f;
			QualitySettings.pixelLightCount = 8;
            camEffects (false, true, false);

			graphicsSett = "Medium";
			Debug.Log ("Low Graphics");

			break;

		case("Medium"):

			//change buttons's icon
			grapMedBtn.GetComponent<Image> ().sprite = grapMSprite;
			grapMedHBtn.GetComponent<Image> ().sprite = grapMSprite;

			//change button's label
			buttonLabel ("MEDIOCRE");

			//grass
			enableGrass (false);

			//graphics quality
			//QualitySettings.SetQualityLevel (2);
			QualitySettings.shadows = ShadowQuality.HardOnly;
			QualitySettings.shadowResolution = ShadowResolution.Low;
			QualitySettings.shadowDistance = 100.0f;
           	QualitySettings.pixelLightCount = 8;

            camEffects (true, true, false);

			graphicsSett = "High";
			Debug.Log ("Medium Graphics");

			break;


		case("High"):

			//change buttons's icon
			grapHighBtn.GetComponent<Image> ().sprite = GrapHSprite;
			grapHighHBtn.GetComponent<Image> ().sprite = GrapHSprite;

			//change button's label
			buttonLabel ("BEAUTIFUL");

			//grass
			enableGrass (true);

			//change graphics quality
			//QualitySettings.SetQualityLevel (3);
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.Medium;
			QualitySettings.shadowDistance = 140.0f;
            QualitySettings.pixelLightCount = 8;

            camEffects (true, true, true);

			graphicsSett = "Low";
			Debug.Log ("High Graphics");

			break;

		default:

			break;
		};


	}

	private void enableGrass(bool enable){


		if (GameObject.FindObjectOfType<Terrain> ()) {
			terrainObj = GameObject.FindObjectOfType<Terrain> ();
			terrainObj.drawTreesAndFoliage = enable;
			terrainInstance (enable);
		}


	}

	private void buttonLabel(string label){

		grapStat.GetComponent<Text> ().text = label;
		grapStatH.GetComponent<Text> ().text = label;

	}

	private void terrainInstance(bool enable){

		if (GameObject.FindGameObjectWithTag ("TerrainInstance")) {

			GameObject.FindGameObjectWithTag ("TerrainInstance").GetComponent<TerrainGrassInstance> ().EnGrassInstance(enable);

		}

	}

	public void camEffects(bool vigAndChrome, bool noiseAndGrain, bool antiAlias){


		if (sceneName == "HomeMenu") {
		
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VignetteAndChromaticAberration> ().enabled = vigAndChrome;
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<NoiseAndGrain> ().enabled = noiseAndGrain;
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Antialiasing> ().enabled = antiAlias;

		}
	}
}
