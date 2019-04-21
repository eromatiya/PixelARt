using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipAscend : MonoBehaviour {

    private Animator anim;
    private bool isPlaying;
    private Scene sceneName;
    private string activeScene;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        sceneName = SceneManager.GetActiveScene();
        activeScene = sceneName.name;
    }
	
	// Update is called once per frame
	void Update () {

        isPlaying = GameObject.FindGameObjectWithTag("Controller").GetComponent<UserInterfaceButtons>().Playing;
    }

    public void RightShipAnim() {

        if (isPlaying)
        {
            if (activeScene == "book2Page1")
            {
                anim.Play("BarrelRollRight");

            }
            else if (activeScene == "book2Page2")
            {

                anim.Play("GlideRight");
            }
            else {

                anim.Play("BarrelRight3");
            }

            anim.SetTrigger("goToEmpty");
            
        }
    }

    public void LeftShipAnim()
    {
        if (isPlaying)
        {
            if (activeScene == "book2Page1")
            {
                anim.Play("BarrelRollLeft");
            }
            else if (activeScene == "book2Page2")
            {

                anim.Play("GlideLeft");
            }
            else {
                anim.Play("BarrelLeft3");
            }
            anim.SetTrigger("goToEmpty");
        }
    }

}
