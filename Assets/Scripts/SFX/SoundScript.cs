using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {


    private Music Music;
    public Image MusicToggleButton;
    public Image MusicToggleButtonHighlight;
    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;
    public Text SoundStatus;
    public Text SoundStatusHightlight;

    void Start() {

        Music = GameObject.FindObjectOfType<Music>();
        UpdateIcon();

    }

    // Update is called once per frame
    void Update() {

    }

	//called in button
    public void UpdateMusic()
    {
        Music.ToggleSound();
        UpdateIcon();
    }

    void UpdateIcon()
    {

        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            MusicToggleButton.GetComponent<Image>().sprite = MusicOnSprite;
            MusicToggleButtonHighlight.GetComponent<Image>().sprite = MusicOnSprite;
            SoundStatus.GetComponent<Text>().text = "MUSIC ON";
            SoundStatusHightlight.GetComponent<Text>().text = "MUSIC ON";
			//Debug.Log (gameObject.name);
        }
        else
        {
            AudioListener.volume = 0;
            MusicToggleButton.GetComponent<Image>().sprite = MusicOffSprite;
            MusicToggleButtonHighlight.GetComponent<Image>().sprite = MusicOffSprite;
            SoundStatus.GetComponent<Text>().text = "MUSIC OFF";
            SoundStatusHightlight.GetComponent<Text>().text = "MUSIC OFF";
			//Debug.Log ("OFF");
        }
    }
        
    
}
