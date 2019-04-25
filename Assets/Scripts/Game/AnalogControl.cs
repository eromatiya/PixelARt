using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class AnalogControl : MonoBehaviour
{

    private Rigidbody rb;
    string currentAnimation = "";


    private Scene sceneName;
    private string activeScene;

    private bool enableLoop = false;

    private float speed;
    // Use this for initialization
    void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
        rb = gameObject.GetComponent<Rigidbody>();

        if (activeScene == "book1Page3") { speed = 0.2f; }
        else { speed = 0.075f; }

    }

    // Update is called once per frame
    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);
       
        rb.velocity = movement * speed;

        if (x != 0 && y != 0)
        {

            //model faces the direction
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        //if Joystick is moved, play animation. Else, idle anim
        if (x != 0 || y != 0)
        {


           

            if (activeScene == "book1Page3" && !enableLoop)
            {
                SetAnimation("isWalking");
                GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().PlayLoopSound();
                enableLoop = true;
            }

            if (activeScene == "book3Page2" && !enableLoop)
            {
                GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().PlayLoopSound();
                enableLoop = true;
            }


        }
        else {
;


            if (activeScene == "book1Page3" && enableLoop)
            {
                SetAnimationIdle();
                GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
                enableLoop = false;
            }

            if (activeScene == "book3Page2" && enableLoop)
            {
               
                GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().StopLoopSound();
                enableLoop = false;
            }


        }

    }


    private void SetAnimation(string animationName)
    {

        if (currentAnimation != "")
        {
            this.GetComponent<Animator>().SetBool(currentAnimation, false);
        }
        this.GetComponent<Animator>().SetBool(animationName, true);
        currentAnimation = animationName;
    }

    private void SetAnimationIdle()
    {

        if (currentAnimation != "")
        {
            this.GetComponent<Animator>().SetBool(currentAnimation, false);
        }
    }
}
