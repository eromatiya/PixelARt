//This script is for panel controlling in home menu
//You can understand it, it's just a basic script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour {

    #region VARIABLES

    public GameObject startPanel;
    public GameObject galleryPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;
    public GameObject chaOnePanel;
    public GameObject chaTwoPanel;
    public GameObject chaThreePanel;
    public GameObject aboPanel;
    public GameObject HowToPopPanel;
	public GameObject HowToPanel;
	public GameObject secretPanel;


	private AudioSource ClickSource { get { return GetComponent<AudioSource>(); } }
	public AudioClip Click; 


    Animator staPanelAnim;
    Animator galPanelAnim;
    Animator helPanelAnim;
    Animator setPanelAnim;
    Animator exiPanelAnim;
    Animator chaOneAnim;
    Animator chaTwoAnim;
    Animator chaThreeAnim;
    Animator tutAnim;
    Animator aboAnim;
	Animator howToAnim;
	Animator howToPopAnim;
	Animator secretAnim;

    CanvasGroup staCanGroup;
    CanvasGroup galCanGroup;
    CanvasGroup helCanGroup;
    CanvasGroup setCanGroup;
    CanvasGroup exiCanGroup;
    CanvasGroup chaOneCanGroup;
    CanvasGroup chaTwoCanGroup;
    CanvasGroup chaThreeCanGroup;
    CanvasGroup tutCanGroup;
    CanvasGroup aboCanGroup;
	CanvasGroup howToPopGroup;
	CanvasGroup howToCanGroup;
	CanvasGroup secretCanGroup;

    #endregion //VARIABLES


    // Use this for initialization
    void Start () {

        GetAnimator();
        GetCanvGroup();

		gameObject.AddComponent<AudioSource>();
		ClickSource.clip = Click;
		ClickSource.playOnAwake = false;
               
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Execute on keycode press
            PanelManager();
			ClickSource.PlayOneShot (Click);
        }

	}

    #region COMPONENT_GETTER

    private void GetAnimator()
    {
        //Gets the Animator component from the gameobject
        //for newbies... components are the scripts or whatever you call it in INSPECTOR
        staPanelAnim = startPanel.GetComponent<Animator>();
        galPanelAnim = galleryPanel.GetComponent<Animator>();
        helPanelAnim = helpPanel.GetComponent<Animator>();
        setPanelAnim = settingsPanel.GetComponent<Animator>();
        exiPanelAnim = exitPanel.GetComponent<Animator>();
        chaOneAnim = chaOnePanel.GetComponent<Animator>();
        chaTwoAnim = chaTwoPanel.GetComponent<Animator>();
        chaThreeAnim = chaThreePanel.GetComponent<Animator>();
        aboAnim = aboPanel.GetComponent<Animator>();
		howToAnim = HowToPanel.GetComponent<Animator> ();
		howToPopAnim = HowToPopPanel.GetComponent<Animator> ();
		secretAnim = secretPanel.GetComponent<Animator> ();
    }

    private void GetCanvGroup()
    {
        //Gets the CanvasGroup component from the gameobject
        staCanGroup = startPanel.GetComponent<CanvasGroup>();
        galCanGroup = galleryPanel.GetComponent<CanvasGroup>();
        helCanGroup = helpPanel.GetComponent<CanvasGroup>();
        setCanGroup = settingsPanel.GetComponent<CanvasGroup>();
        exiCanGroup = exitPanel.GetComponent<CanvasGroup>();
        chaOneCanGroup = chaOnePanel.GetComponent<CanvasGroup>();
        chaTwoCanGroup = chaTwoPanel.GetComponent<CanvasGroup>();
        chaThreeCanGroup = chaThreePanel.GetComponent<CanvasGroup>();
        aboCanGroup = aboPanel.GetComponent<CanvasGroup>();
		howToCanGroup = HowToPanel.GetComponent<CanvasGroup> ();
		howToPopGroup = HowToPopPanel.GetComponent<CanvasGroup> ();
		secretCanGroup = secretPanel.GetComponent<CanvasGroup> ();

    }


    #endregion // COMPONENT_GETTER

    




	private void PanelManager()
    {
        //Call Functions
		if(staCanGroup.alpha == 1)
        	PanelStart();
        
		if (galCanGroup.alpha == 1)
			PanelGallery ();
        
		if (helCanGroup.alpha == 1)
			PanelHelp ();
        
		if (setCanGroup.alpha == 1)
			PanelSett ();
		
		if (howToPopGroup.alpha == 1)
			PanelInstructPop ();

		if (secretCanGroup.alpha == 1)
			PanelSecret ();

		PanelExit ();
    }

    
    #region PANEL_CONTROLLER_FUNCTIONS

    private void PanelStart()
    {
        if (chaOneCanGroup.alpha == 1)
            chaOneAnim.Play("Panel Out");

        if (chaTwoCanGroup.alpha == 1)
            chaTwoAnim.Play("Panel Out");

        if (chaThreeCanGroup.alpha == 1)
            chaThreeAnim.Play("Panel Out");

        if (chaOneCanGroup.alpha == 0)
            if (chaTwoCanGroup.alpha == 0)
                if (chaThreeCanGroup.alpha == 0)
                    if(staCanGroup.alpha == 1)
                        staPanelAnim.Play("Panel Out");
        
    }

    private void PanelGallery()
    {
        if (galCanGroup.alpha == 1)
            galPanelAnim.Play("Panel Out");
    }

    private void PanelHelp()
    {
        if (aboCanGroup.alpha == 1)
            aboAnim.Play("Panel Out");

		if (howToCanGroup.alpha == 1)
			howToAnim.Play ("Panel Out");


        if (aboCanGroup.alpha == 0)
			if(howToCanGroup.alpha == 0)
				if (helCanGroup.alpha == 1)
                   	helPanelAnim.Play("Panel Out");


    }


    private void PanelSett()
    {
        if (setCanGroup.alpha == 1)
            setPanelAnim.Play("Panel Out");
                              
    }

    private void PanelExit()
    {
		if(secretCanGroup.alpha == 0)
			if (exiCanGroup.alpha == 0)
				if(howToPopGroup.alpha == 0)
            		if (staCanGroup.alpha == 0)
                		if (galCanGroup.alpha == 0)
                    		if (helCanGroup.alpha == 0)
                        		if (setCanGroup.alpha == 0)
                            		if (exiCanGroup.alpha == 0)
                                		exiPanelAnim.Play("Panel In");



        if (exiCanGroup.alpha == 1)
                            exiPanelAnim.Play("Panel Out");

    }

	private void PanelSecret(){
	
		if (secretCanGroup.alpha == 1) {
		
			secretAnim.Play ("Panel Out");
		}
	}

    private void PanelInstructPop()
    {
		if (howToPopGroup.alpha == 1)
			howToPopAnim.Play ("Panel Out");
    }
    #endregion // PANEL_CONTROLLER_FUNCTIONS
}
