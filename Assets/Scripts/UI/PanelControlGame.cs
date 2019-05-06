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

	public GameObject pagesPanel;
	public GameObject chapter1Panel;
	public GameObject chapter2Panel;
	public GameObject chapter3Panel;



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
	Animator helpAnim;
    Animator natureAnim;
	Animator pagesAnim;
	Animator chap1Anim;
	Animator chap2Anim;
	Animator chap3Anim;

    CanvasGroup optCanGroup;
    CanvasGroup toMainCanGroup;
	CanvasGroup invCanGroup;
	CanvasGroup invTreeCanGroup;
	CanvasGroup invWoodsCanGroup;
	CanvasGroup saveCanGroup;
	CanvasGroup loadCanGroup;
	CanvasGroup delCanGroup;
	CanvasGroup helpCanGroup;
    CanvasGroup natureCanGroup;
	CanvasGroup pagesCanGroup;
	CanvasGroup chap1CanGroup;
	CanvasGroup chap2CanGroup;
	CanvasGroup chap3CanGroup;

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

        if (GameObject.Find("NaturePanel"))
        {

            naturePanel = GameObject.Find("NaturePanel");
            natureAnim = naturePanel.GetComponent<Animator>();
            natureCanGroup = naturePanel.GetComponent<CanvasGroup>();

        }
        else if (GameObject.Find("MiscPanel"))
        {

            naturePanel = GameObject.Find("MiscPanel");
            natureAnim = naturePanel.GetComponent<Animator>();
            natureCanGroup = naturePanel.GetComponent<CanvasGroup>();

        }
        else if (GameObject.Find("StructuresPanel"))
        {

            naturePanel = GameObject.Find("StructuresPanel");
            natureAnim = naturePanel.GetComponent<Animator>();
            natureCanGroup = naturePanel.GetComponent<CanvasGroup>();

        }
        else {

            naturePanel = null;

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
		helpCanGroup = HelpPanel.GetComponent<CanvasGroup> ();
		pagesCanGroup = pagesPanel.GetComponent<CanvasGroup> ();
		chap1CanGroup = chapter1Panel.GetComponent<CanvasGroup> ();;
		chap2CanGroup = chapter2Panel.GetComponent<CanvasGroup> ();;
		chap3CanGroup = chapter3Panel.GetComponent<CanvasGroup> ();;
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
		helpAnim = HelpPanel.GetComponent<Animator> ();
		pagesAnim = pagesPanel.GetComponent<Animator> ();
		chap1Anim = chapter1Panel.GetComponent<Animator> ();
		chap2Anim = chapter2Panel.GetComponent<Animator> ();
		chap3Anim = chapter3Panel.GetComponent<Animator> ();
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

		if (helpCanGroup.alpha == 1) {
		
			helpAnim.Play ("Panel Out");
		}


        if (naturePanel && natureCanGroup.alpha == 1) {

            natureAnim.Play("Panel Out");
            
        }
            

		if (invTreeCanGroup.alpha == 0) {
			if (invWoodsCanGroup.alpha == 0) {

                if (naturePanel == null || natureCanGroup.alpha == 0)
                {
                    if (invCanGroup.alpha == 1)
                    {

                        invAnim.Play("Panel Out");

                    }
                }
			}
		}

		if (toMainCanGroup.alpha == 1) {
			toMainAnim.Play ("Panel Out");
		}

		if (toMainCanGroup.alpha == 0) {   
			
			if (chap3CanGroup.alpha == 0) {
			
				if (chap2CanGroup.alpha == 0) {
			
					if (chap1CanGroup.alpha == 0) {
			
						if (pagesCanGroup.alpha == 0) {
			
							if (helpCanGroup.alpha == 0) {
				
								if (optCanGroup.alpha == 0) {
					
									if (invCanGroup.alpha == 0) {
						
										if (!naturePanel || natureCanGroup.alpha == 0) {
							
											if (saveCanGroup.alpha == 0) {
								
												if (loadCanGroup.alpha == 0) {
									
													if (delCanGroup.alpha == 0) {
														optAnim.Play ("Panel In");
														GameObject.FindGameObjectWithTag ("Controller").GetComponent<UserInterfaceButtons> ().PauseGame ();
                                        
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}


			if(chap3CanGroup.alpha == 0){
				if (chap2CanGroup.alpha == 0) {
					if (chap1CanGroup.alpha == 0) {
						if (pagesCanGroup.alpha == 1) {

							pagesAnim.Play ("Panel Out");
						}
					}
				}
			}


			if(chap3CanGroup.alpha == 0){
				if (chap2CanGroup.alpha == 0) {
					if (chap1CanGroup.alpha == 0) {
						if (pagesCanGroup.alpha == 0) {
							if (optCanGroup.alpha == 1) {
								optAnim.Play ("Panel Out");
							}
						}
					}
				}
			}
		}

 
		if (chap1CanGroup.alpha == 1) {

			chap1Anim.Play ("Panel Out");

		}

		if (chap2CanGroup.alpha == 1) {

			chap2Anim.Play ("Panel Out");

		}

		if (chap3CanGroup.alpha == 1) {

			chap3Anim.Play ("Panel Out");

		}

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
