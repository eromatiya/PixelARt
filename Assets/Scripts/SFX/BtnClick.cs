using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnClick : MonoBehaviour {


    public AudioClip Click;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start () {

        gameObject.AddComponent<AudioSource>();
        source.clip = Click;
        source.playOnAwake = false;
        button.onClick.AddListener(() => ClickSound());
	}
	
	void ClickSound()
    {
        source.PlayOneShot(Click);
    }
}
