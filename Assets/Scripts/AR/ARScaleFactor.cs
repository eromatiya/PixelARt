using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARScaleFactor : MonoBehaviour {

    private GameObject arMarker;
    private float origScaleVal;
    private Scene sceneName;
    private string activeScene;

    // Use this for initialization
    void Start () {

        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
        arMarker = GameObject.Find("ARController");
        origScaleVal = arMarker.GetComponent<ARMarker>().NFTScale;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void decreaseARScale() {

        if (activeScene == "book1Page1")
        {
                arMarker.GetComponent<ARMarker>().NFTScale = 40;

        }
        else if (activeScene == "book1Page2")
        {
            arMarker.GetComponent<ARMarker>().NFTScale = 7;

        }
        else if (activeScene == "book1Page3" || activeScene == "book3Page2") {

            arMarker.GetComponent<ARMarker>().NFTScale = 5;

        }
        else if (activeScene == "book2Page1" || activeScene == "book2Page2" || activeScene == "book2Page3")
        {

            arMarker.GetComponent<ARMarker>().NFTScale = 20;
        }
        else if (activeScene == "book3Page1" || activeScene == "book3Page3")
        {

            arMarker.GetComponent<ARMarker>().NFTScale = 35;
        }

    }

    public void returnOrigARScale() {

        arMarker.GetComponent<ARMarker>().NFTScale = origScaleVal;

    }
}
