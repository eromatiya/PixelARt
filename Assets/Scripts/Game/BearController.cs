using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class BearController : MonoBehaviour
{

    private Rigidbody rb;
    string currentAnimation = "";


    private Scene sceneName;
    private string activeScene;

    private bool enableLoop = false;

    // Use this for initialization
    void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);
        rb.velocity = movement * 0.2f;

        if (x != 0 && y != 0)
        {

            //model faces the direction
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        //if Joystick is moved, play animation. Else, idle anim
        if (x != 0 || y != 0)
        {


            SetAnimation("isWalking");

            if (activeScene == "book1Page3" && !enableLoop)
            {
                GameObject.FindGameObjectWithTag("SFXController").GetComponent<ModelSoundManager>().PlayLoopSound();
                enableLoop = true;
            }

        }
        else {

            SetAnimationIdle();


            if (activeScene == "book1Page3" && enableLoop)
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
