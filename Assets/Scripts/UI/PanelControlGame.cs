//This script is for panels inside coloring book 
//Just understand it. too lazy to explain

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelControlGame : MonoBehaviour {

    public GameObject optPanel;
    public GameObject toMainPanel;
    public GameObject HelpPanel;
	public GameObject gOverScreen;
	public GameObject invPanel;
	public GameObject invTreePanel;
	public GameObject invWoodsPanel;
	public GameObject savePanel;
	public GameObject loadPanel;
	public GameObject delPanel;
    GameObject naturePanel;

	private AudioSource ClickSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip Click; 

    Animator optAnim;
    Animator toMainAnim;
	Animator invAnim;
	Animator invTreeAnim;
	Animator invWoodsAnim;
	Animator saveAnim;
	Animator loadAnim;
	Animator delAnim;
    Animator natureAnim;

    CanvasGroup optCanGroup;
    CanvasGroup toMainCanGroup;
	CanvasGroup invCanGroup;
	CanvasGroup invTreeCanGroup;
	CanvasGroup invWoodsCanGroup;
	CanvasGroup saveCanGroup;
	CanvasGroup loadCanGroup;
	CanvasGroup delCanGroup;
    CanvasGroup natureCanGroup;

    private Scene sceneName;
    private string activeScene;

    // Use this for initialization
    void Start () {
		
		gameObject.AddComponent<AudioSource>();
		ClickSource.clip = Click;
		ClickSource.playOnAwake = false;

        //Use Variables
        CanGroupGetComp();
        AnimGetComp();

        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;


        if (activeScene == "book2Page2" || activeScene == "book2Page3") {

            naturePanel = GameObject.Find("NaturePanel");
            natureAnim = naturePanel.GetComponent<Animator>();
            natureCanGroup = naturePanel.GetComponent<CanvasGroup>();
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //Calls PanelController()
            PanelController();
			ClickSource.PlayOneShot (Click);

        }
        

    }
    
    #region GET_COMPONENT_VARIABLES
    public void CanGroupGetComp()
    {
        optCanGroup = optPanel.GetComponent<CanvasGroup>();
        toMainCanGroup = toMainPanel.GetComponent<CanvasGroup>();
		invCanGroup = invPanel.GetComponent<CanvasGroup> ();
		invTreeCanGroup = invTreePanel.GetComponent<CanvasGroup> ();
		invWoodsCanGroup = invWoodsPanel.GetComponent<CanvasGroup> ();
		saveCanGroup = savePanel.GetComponent<CanvasGroup> ();
		loadCanGroup = loadPanel.GetComponent<CanvasGroup> ();
		delCanGroup = delPanel.GetComponent<CanvasGroup> ();
    }

    public void AnimGetComp()
    {
        optAnim = optPanel.GetComponent<Animator>();
        toMainAnim = toMainPanel.GetComponent<Animator>();
		invAnim = invPanel.GetComponent<Animator> ();
		invTreeAnim = invTreePanel.GetComponent<Animator> ();
		invWoodsAnim = invWoodsPanel.GetComponent<Animator> ();
		saveAnim = savePanel.GetComponent<Animator> ();
		loadAnim = loadPanel.GetComponent<Animator> ();
		delAnim = delPanel.GetComponent<Animator> ();
	}


    #endregion //GET_COMPONENT
       
    public void PanelController()
    {
		if (delCanGroup.alpha == 1) {
		
			delAnim.Play ("Panel Out");
		}

		if (saveCanGroup.alpha == 1) {
		
			saveAnim.Play ("Panel Out");
		}

		if (loadCanGroup.alpha == 1) {
		
			loadAnim.Play ("Panel Out");
		}


		if (invTreeCanGroup.alpha == 1) {

			invTreeAnim.Play ("Panel Out");	

		}

		if (invWoodsCanGroup.alpha == 1) {

			invWoodsAnim.Play ("Panel Out");	

		}

        if (naturePanel && natureCanGroup.alpha == 1) {

            natureAnim.Play("Panel Out");
            
        }
            

		if (invTreeCanGroup.alpha == 0) {
			if (invWoodsCanGroup.alpha == 0) {
				if (invCanGroup.alpha == 1)       {

					invAnim.Play ("Panel Out");

				}
			}
		}

		if (toMainCanGroup.alpha == 1) {
			toMainAnim.Play ("Panel Out");
		}

        if (toMainCanGroup.alpha == 0)
        {   
            
		
			if (!gOverScreen.activeSelf) {
				if (optCanGroup.alpha == 0) {
					if (invCanGroup.alpha == 0) {
                        if (!naturePanel || natureCanGroup.alpha == 0) {
                            if (saveCanGroup.alpha == 0) {
                                if (loadCanGroup.alpha == 0) {
                                    if (delCanGroup.alpha == 0) {
                                        if (!HelpPanel.activeSelf) {
                                            optAnim.Play("Panel In");
                                            GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().PauseGame();
                                        }
                                    }
                                }
                            }
                        }
					}
				}
			}

			if (optCanGroup.alpha == 1) {
				optAnim.Play ("Panel Out");
			}

        }

 
        if (HelpPanel.activeSelf)
            HelpPanel.SetActive(false);

		if (gOverScreen.activeSelf) {

			gOverScreen.SetActive (false);
			GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().stopGameOnKeyPress ();


		}





    }

	public void CloseTreesPan(){
	
		invAnim.Play ("Panel Out");
		invTreeAnim.Play ("Panel Out");

	}

	public void CloseWoodsPan(){
	
		invAnim.Play ("Panel Out");
		invWoodsAnim.Play ("Panel Out");
	
	}


	public void CloseInvPan(){

		invAnim.Play ("Panel Out");

	}

    public void CloseNaturePan() {

        if (naturePanel) {

            invAnim.Play("Panel Out");
            natureAnim.Play("Panel Out");

        }

    }
		
}
