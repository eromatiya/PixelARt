//This Script handles the GAME and UI inside the BOOKS of this APPLICATION
//it is Attached to GameController obj

//P.S. crappy coding. 
//pps. I FCKING HATE THIS SCRIPT. FUCK THIS SHIT.

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Vuforia;

public class UserInterfaceButtons : MonoBehaviour
{

    //GameObjects
	public GameObject gizmoCamera;
    public GameObject Model;
    public GameObject AROnBtn;
    public GameObject AROffBtn;
    public GameObject ImageTarget;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject ScoreBoard;
    public GameObject Environment;
    public GameObject TileManager;
    public GameObject StopGame;
    public GameObject StartGame;
    public GameObject RestartBtn;
    public GameObject UIPanel;
    public GameObject MovePanel;
    public GameObject Crosshair;
    public GameObject HelpButton;
	public GameObject StarBoard;
	public GameObject sandBoxOnButton;
	public GameObject sandBoxOffButton;
	public GameObject sandBoxPanel;
	public GameObject sandboxSaveLoadPanel;
	public GameObject toggleSandboxBtn;
	public GameObject spawner;
	public GameObject sandboxManager;   
	public GameObject toggleFlashLightBtn;
    public GameObject modelTexture;
    public GameObject sfxManager;

	public Sprite showSandboxSprite;
	public Sprite hideSandboxSprite;
	public Sprite onFlashLightSprite;
	public Sprite offFlassLightSprite;


    public float scalingSpeed = 0.03f;
	public float rotationSpeed = 100.0f;
	public float translationSpeed = 5.0f;
//	public GameObject Model;
	bool repeatScaleUp = false;
	bool repeatScaleDown = false;
	bool repeatRotateLeft = false;
	bool repeatRotateRight = false;
	bool repeatPositionUp = false;
	bool repeatPositionDown = false;
	bool repeatPositionLeft = false;
	bool repeatPositionRight = false;


    //  Game
    // public float PlaySpeed = 5.0f;
	private bool isSandbox = false;
	private bool isInGame = false;
	public bool Playing = false;
    private bool isOnTarget = false;
    private bool isAROn = true;
	private bool togglingSandbox = false;
	private bool togglingFLight = false;
	private bool isExtendedTracking = false;

    private Scene sceneName;
    private string activeScene;
    string currentAnimation="";

    void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
    }

    void Update ()
	{
		if (repeatScaleUp) {
			ScaleUpButton ();
		}

		if (repeatScaleDown) {
			ScaleDownButton ();
		}

		if (repeatRotateRight) {
			RotationRightButton();
		}

		if (repeatRotateLeft) {
			RotationLeftButton();
		}

		if (repeatPositionUp) {
			PositionUpButton();
		}

		if (repeatPositionDown) {
			PositionDownButton();
		}

		if (repeatPositionLeft) {
			PositionLeftButton();
		}

		if (repeatPositionRight) {
			PositionRightButton();
		}

        if (PauseButton.activeSelf && Playing == false)
        {
            PlayButton.SetActive(true);
            PauseButton.SetActive(false);
        }


    }

	public void CloseAppButton ()
	{
		Application.Quit ();
	}

    
	public void RotationRightButton ()
	{
        // transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);

        if (activeScene == "book2Page1" || activeScene == "book2Page2" || activeScene == "book2Page3")
        {

            Model.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Model.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

	}

	public void RotationLeftButton ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);

        if (activeScene == "book2Page1" || activeScene == "book2Page2" || activeScene == "book2Page3")
        {

            Model.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else
        {
            Model.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

	public void RotationRightButtonRepeat ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		repeatRotateRight=true;
	}
	
	public void RotationLeftButtonRepeat ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		repeatRotateLeft=true;
	}

	public void ScaleUpButton ()
	{
		// transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
			Model.transform.localScale += new Vector3 (scalingSpeed, scalingSpeed, scalingSpeed);
		}

	public void ScaleUpButtonRepeat ()
	{
		repeatScaleUp = true;
		Debug.Log ("Up");
	}
	public void ScaleDownButtonRepeat ()
	{
		repeatScaleDown = true;
		Debug.Log ("Down");
	}
	public void PositionDownButtonRepeat ()
	{
		repeatPositionDown = true;
	}
	public void PositionUpButtonRepeat ()
	{
		repeatPositionUp = true;
	}
	public void PositionLeftButtonRepeat ()
	{
		repeatPositionLeft = true;
	}
	public void PositionRightButtonRepeat ()
	{
		repeatPositionRight = true;
	}
	
	public void ScaleUpButtonOff ()
	{
		repeatScaleUp = false;
		Debug.Log ("Off");
	}
	public void ScaleDownButtonOff ()
	{
		repeatScaleDown = false;
		Debug.Log ("Off");
	}

	public void RotateLeftButtonOff ()
	{
		repeatRotateLeft = false;
		Debug.Log ("Off");
	}

	public void RotateRightButtonOff ()
	{
		repeatRotateRight = false;
		Debug.Log ("Off");
	}
	public void PositionRightButtonOff ()
	{
		repeatPositionRight = false;
		Debug.Log ("Off");
	}
	public void PositionLeftButtonOff ()
	{
		repeatPositionLeft = false;
		Debug.Log ("Off");
	}
	public void PositionUpButtonOff ()
	{
		repeatPositionUp = false;
		Debug.Log ("Off");
	}
	public void PositionDownButtonOff ()
	{
		repeatPositionDown = false;
		Debug.Log ("Off");
	}
	
	public void ScaleDownButton ()
	{
		// transform.localScale += new Vector3(-scalingSpeed, -scalingSpeed, -scalingSpeed);
		Model.transform.localScale += new Vector3 (-scalingSpeed, -scalingSpeed, -scalingSpeed);
	}

	public void PositionUpButton ()
	{
		Model.transform.Translate (0, 0, -translationSpeed * Time.deltaTime);
	}

	public void PositionDownButton ()
	{

		Model.transform.Translate (0, 0, translationSpeed * Time.deltaTime);
	}

	public void PositionRightButton ()
	{
		Model.transform.Translate (-translationSpeed * Time.deltaTime, 0, 0);
	}

	public void PositionLeftButton ()
	{
		Model.transform.Translate (translationSpeed * Time.deltaTime, 0, 0);  // backward
	}

	public void ChangeScene (string a)
	{
	    //Application.LoadLevel (a);
	}

	public void AnyButton ()
	{
		Debug.Log ("Any");
	}

    public void ToggleAR()
    {

        if (AROnBtn.activeSelf)
        {
            //red button
            AROnBtn.SetActive(false);   
            AROffBtn.SetActive(true);
            ImageTarget.SetActive(false);

            
            if(isOnTarget == true)
            {
               // StartGame.SetActive(false);
                StartGame.GetComponent<Button>().interactable = false;
                sandBoxOnButton.GetComponent<Button>().interactable = false;
                sfxManager.GetComponent<ModelSoundManager>().StopAllSFX();
            }
            isAROn = false;
            //Debug.Log(isAROn);
        }
        else
        {

            //green button
            AROnBtn.SetActive(true);
            AROffBtn.SetActive(false);
            ImageTarget.SetActive(true);
            StartGame.SetActive(true);

			if (isOnTarget && isSandbox == false && isInGame == false) {
				StartGame.GetComponent<Button> ().interactable = true;
				sandBoxOnButton.GetComponent<Button> ().interactable = true;
                sfxManager.GetComponent<ModelSoundManager>().EnableRandomSound();
            }

            isAROn = true;
            //Debug.Log(isAROn);
        }
    }

    public void GameStart()
    {
        //Reduce size of model in game
        gameOnModPos();
        MovePanel.SetActive(true);
		isInGame = true;
		sandBoxOnButton.GetComponent<Button> ().interactable = false;
        modelTexture.GetComponent<RC_Get_Texture>().FreezeEnable = true;
        decARScale();

        if (activeScene != "book1Page3")
        {
            sfxManager.GetComponent<ModelSoundManager>().PlayLoopSound();
        }

        if (togglingSandbox) {
		
			HideSandbox ();
		}

        //Enable MODEL SFX
        

        if (Playing == false)
            Playing = true;
            
        
    }

    public void GameStop()
    {
        //Scale up size of model in game
        gameOffModPos();
		isInGame = false;
        MovePanel.SetActive(false);
        Environment.GetComponent<RunZ>().StartGame();
		TileManager.GetComponent<TileManager> ().KillTileChildren ();
        Environment.SetActive(false);
        ScoreBoard.SetActive(false);
        Model.GetComponent<HitObstacle>().isOver = false;
        gameObject.GetComponent<ScoreScript>().ResetScores();
        StartGame.SetActive(true);
        StopGame.SetActive(false);
        Playing = false;
        //sandBoxOnButton.GetComponent<Button> ().interactable = true;
        //DisableExtTracking (); to be removed
        modelTexture.GetComponent<RC_Get_Texture>().FreezeEnable = false;


        origARScale();

        if (!isOnTarget || !isAROn) {
            StartGame.GetComponent<Button>().interactable = false;
			sandBoxOnButton.GetComponent<Button>().interactable = false;
        }

        if (isOnTarget && isAROn) {
            sandBoxOnButton.GetComponent<Button>().interactable = true;
        }

        //Control model animations
        PlayPauseAnim();

        sfxManager.GetComponent<ModelSoundManager>().StopLoopSound();

    }

    public void PauseGame()
    {
        if (Environment.activeSelf)
            Playing = false;

        PlayPauseAnim();

        sfxManager.GetComponent<ModelSoundManager>().StopLoopSound();
    }

    public void PlayGame()
    {
        if (Playing == false)
            Playing = true;

        if (activeScene != "book1Page3")
        {
            sfxManager.GetComponent<ModelSoundManager>().PlayLoopSound();
        }

        Debug.Log("Play");
        Environment.GetComponent<RunZ>().RunNow();
        PlayPauseAnim();
    }


    //Pause the Game if AR is turned off while playing
    public void PauseOnStopGame()
    {
        if (Playing == true)
            Playing = false;

    }

    //Restart Game after GameOver
    public void RestartGame()
    {
        Playing = true;
        gameOnModPos();
		
        Model.GetComponent<HitObstacle>().isOver = false;
        gameObject.GetComponent<ScoreScript>().ResetScores();
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
        
        if (activeScene != "book1Page3")
        {

            TileManager.GetComponent<TileManager>().KillTileChildren();
            Environment.GetComponent<RunZ>().StartGame();
            Environment.GetComponent<RunZ>().ResetSpeed();
            sfxManager.GetComponent<ModelSoundManager>().PlayLoopSound();
        }

    }




    //Set Model position and rotation in game
    private void gameOnModPos()
    {
        UIPanel.SetActive(false);



        if (activeScene == "book1Page1")
        {
            Model.transform.position = new Vector3(0.0f, 0, 0);
            Model.transform.localScale = new Vector3(1f, 1f, 1f);
            Model.transform.eulerAngles = new Vector3(0, 0, 0);
            SetAnimation("isRunning");
        }

        else if (activeScene == "book1Page2")
        {

            Model.transform.position = new Vector3(0.0f, 0.0982f, 0.0f);
            Model.transform.localScale = new Vector3(1f, 1f, 1f);
            Model.transform.eulerAngles = new Vector3(0, 0, 0);
            SetAnimation("isAttacking");
        }
        else if (activeScene == "book1Page3") {

            Model.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
        else if (activeScene == "book2Page1" || activeScene == "book2Page2" || activeScene == "book2Page3")
        {

            Model.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Model.transform.localScale = new Vector3(1f, 1f, 1f);
            Model.transform.localEulerAngles = new Vector3(0, 0.0f, 180.0f);

        }

    }

    //Restore original position and panel control after game
    private void gameOffModPos()
    {
        UIPanel.SetActive(true);
        Model.transform.position = new Vector3(0, 0, 0);
        Model.transform.localScale = new Vector3(1, 1, 1);

        if (activeScene == "book2Page1" || activeScene == "book2Page2" || activeScene == "book2Page3")
        {
            Model.transform.localEulerAngles = new Vector3(0, 0.0f, 0);
        }
        else { Model.transform.eulerAngles = new Vector3(0, 180, 0); }

        SetAnimationIdle();
    }


	#region On_Target_Lost_and_Found

    //execute when target lost, referenced in DefaultTrackableEventHandler script in ImageTarget
    public void onTargetLost()
    {
        PauseGame();
        PauseButton.SetActive(false);

	
        if (StartGame.activeSelf)
            StartGame.GetComponent<Button>().interactable = false;

        if (MovePanel.activeSelf)
            MovePanel.SetActive(false);

        if (RestartBtn.activeSelf)
            RestartBtn.GetComponent<Button>().interactable = false;     

        if (!Crosshair.activeSelf)
            Crosshair.SetActive(true);

		if (StopGame.activeSelf)
			PlayButton.SetActive (true);

		if (sandBoxOnButton.activeSelf)
			sandBoxOnButton.GetComponent<Button> ().interactable = false;

		if (PlayButton.activeSelf) {
			
			PlayButton.GetComponent<Button> ().interactable = false;
		}

        if (sandboxManager.activeSelf) sandboxManager.SetActive(false);
      
        

		gizmoCamera.GetComponent<Camera> ().enabled = false;
		//if(PlayButton.activeSelf && Playing == true)

        sfxManager.GetComponent<ModelSoundManager>().StopAllSFX();

        isOnTarget = false;
    }

    //execute when targetfound, referenced in DefaultTrackableEventHandler script in ImageTarget
    public void onTargetFound()
    {

        if (Playing == false && StopGame.activeSelf)
        {
            PlayButton.SetActive(true);
            PlayButton.GetComponent<Button>().interactable = true;
        }

        

        if (!StopGame.activeSelf && isAROn == true && isSandbox == false)
            StartGame.GetComponent<Button>().interactable = true;
            //StartGame.SetActive(true);

        if (!MovePanel.activeSelf && StopGame.activeSelf && activeScene != "book1Page3")
            MovePanel.SetActive(true);

        //if (!RestartBtn.activeSelf)
        //    RestartBtn.SetActive(true);

        if (RestartBtn.GetComponent<Button>().interactable == false)
            RestartBtn.GetComponent<Button>().interactable = true;

        if (Crosshair.activeSelf)
            Crosshair.SetActive(false);

		if (sandBoxOnButton.activeSelf && isInGame == false && isAROn == true) {
			sandBoxOnButton.GetComponent<Button> ().interactable = true;
		}

		gizmoCamera.GetComponent<Camera> ().enabled = true;

        if (!sandboxManager.activeSelf) sandboxManager.SetActive(true);

        sfxManager.GetComponent<ModelSoundManager>().EnableRandomSound();

        isOnTarget = true;

    }

	#endregion //On_Target_Lost_and_Found


	#region Game_Control
    //Button Control
    public void MoveLeft()
    {
        if(Playing==true)
            Model.GetComponent<ModelMove>().MoveLeft();
    }

    public void MoveRight()
    {
        if (Playing == true)
            Model.GetComponent<ModelMove>().MoveRight();
    }


	#endregion //Game_Control

	public void stopGameOnKeyPress(){
	
		GameStop ();
		
		StartGame.SetActive (true);
		StopGame.SetActive (false);
		StarBoard.SetActive (false);
	}




	#region toggle_sandbox_mode



	public void SandBoxOn(){

		spawner.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);

        //ResizeModel(0.3f, 0.3f, 0.3f);
        decARScale();

		if (!isExtendedTracking) {
            //EnableExtTracking (); to be removed
            isExtendedTracking = true;
		}
		UIPanel.SetActive (false);	
		sandBoxPanel.SetActive (true);
		sandboxSaveLoadPanel.SetActive (true);
		sandBoxOnButton.SetActive (false);
		sandBoxOffButton.SetActive (true);
		StartGame.GetComponent<Button>().interactable = false;
		spawner.SetActive (true);
		isSandbox = true;
        //regionCapture.SetActive (false);
        modelTexture.GetComponent<RC_Get_Texture>().FreezeEnable = true;
		sandboxManager.GetComponent<SaveLoadSystem> ().LoadState ();


		if (togglingSandbox) {
		
			togglingSandbox = false;
			toggleSandboxBtn.GetComponent<UnityEngine.UI.Image> ().sprite = showSandboxSprite;

		}


	}

	public void SandBoxOff(){

        //ResizeModel(1.0f, 1.0f, 1.0f);
        origARScale();

        if (isExtendedTracking) {
            //DisableExtTracking (); to be removed
            isExtendedTracking = false;
		}
		UIPanel.SetActive (true);
		sandBoxPanel.SetActive (false);
		sandboxSaveLoadPanel.SetActive (false);
		sandBoxOffButton.SetActive (false);
		sandBoxOnButton.SetActive (true);
		sandboxManager.GetComponent<SaveLoadSystem> ().DestroyChildren ();
        //regionCapture.SetActive (true);
        modelTexture.GetComponent<RC_Get_Texture>().FreezeEnable = false;

		if (togglingSandbox) {
		
			sandboxManager.GetComponent<SaveLoadSystem> ().LoadState ();
		}

		if (!isOnTarget) {
			sandBoxOnButton.GetComponent<Button> ().interactable = false;
		}
		if (isOnTarget && isAROn) {
		
			StartGame.GetComponent<Button> ().interactable = true;
		}

		isSandbox = false;
	}

	#endregion // toggle_sandbox_mode



	#region show_hide_sandbox


	public void ToggleSandbox(){
	
		if (togglingSandbox) {

			//Hide sandbox
			HideSandbox();

		} else {
			
			//show sandbox
			if (isOnTarget && isAROn) {
				ShowSandbox ();
			}
		}

	}

	private void HideSandbox(){
	
		spawner.SetActive (false);
		toggleSandboxBtn.GetComponent<UnityEngine.UI.Image> ().sprite = showSandboxSprite;
		togglingSandbox = false;
		sandboxManager.GetComponent<SaveLoadSystem> ().DestroyChildren ();
		if (isExtendedTracking) {
			//DisableExtTracking (); to be removed
			isExtendedTracking = false;
		}
		spawner.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	private void ShowSandbox(){
	
		spawner.SetActive (true);
		toggleSandboxBtn.GetComponent<UnityEngine.UI.Image> ().sprite = hideSandboxSprite;
		togglingSandbox = true;
		sandboxManager.GetComponent<SaveLoadSystem> ().LoadState ();

		if (!isExtendedTracking) {
            //EnableExtTracking (); to be removed
            isExtendedTracking = true;
		}
		spawner.transform.localPosition = new Vector3 (0.0f, -0.1001f, 0.0f);

	}



    #endregion //show_hide_sandbox


    /*
    #region toggle_extended_tracking


    private void EnableExtTracking()
    {

        PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        pdt.Start();
    }

    private void DisableExtTracking()
    {

        PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        if (pdt != null && pdt.IsActive)

        {
            pdt.Stop();
        }
    }

    #endregion  //toggle_extended_tracking
    */


    #region toggle_flashlight

    public void ToggleFLight()
    {

        if (!togglingFLight)
        {
            //Enable FlashLight
            toggleFlashLightBtn.GetComponent<UnityEngine.UI.Image>().sprite = offFlassLightSprite;
            togglingFLight = !togglingFLight;
        }
        else
        {
            //Disable Flashlight
            toggleFlashLightBtn.GetComponent<UnityEngine.UI.Image>().sprite = onFlashLightSprite;
            togglingFLight = !togglingFLight;
        }
    }


    #endregion //toggle_flaslight





    #region RESIZE_MODEL()

    //Size of model in Sandbox
    private void ResizeModel(float x, float y, float z) {
        //Modify switch
        switch (activeScene){

            case ("book1Page1"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;
                                
            case ("book1Page2"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;

            case ("book1Page3"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;

            case ("book2Page1"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;

            case ("book2Page2"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;

            case ("book2Page3"):

                Model.GetComponent<Transform>().localScale = new Vector3(x, y, z);
                break;

            default:
                break;
        }


    }



    #endregion //RESIZE_MODEL()



    #region MODEL_ANIM_CONTROL

    public void SetAnimation(string animationName)
    {

        if (currentAnimation != "")
        {
            Model.GetComponent<Animator>().SetBool(currentAnimation, false);
        }
        Model.GetComponent<Animator>().SetBool(animationName, true);
        currentAnimation = animationName;
    }

    public void SetAnimationIdle()
    {

        if (currentAnimation != "")
        {
            Model.GetComponent<Animator>().SetBool(currentAnimation, false);
        }


    }

    #endregion




    #region PlayPauseAnim

    public void PlayPauseAnim() {

        switch (activeScene) {
            case ("book1Page1"):

                if (Playing)
                {
                    SetAnimation("isRunning");
                }
                else {
                    SetAnimationIdle();
                }
                break;
            case ("book1Page2"):

                if (Playing)
                {
                    SetAnimation("isAttacking");
                }
                else
                {
                    SetAnimationIdle();
                }
                break;
            default:
                break;


        }
        
    }


    #endregion




    #region AR_SCALER

    private void decARScale()
    {

        gameObject.GetComponent<ARScaleFactor>().decreaseARScale();

    }

    private void origARScale() {

        gameObject.GetComponent<ARScaleFactor>().returnOrigARScale();
    }


    #endregion
}
