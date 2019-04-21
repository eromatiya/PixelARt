using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    /*
	public void pageDuck()
    {
        SceneManager.LoadScene("ARDuck");
    }
    */

    public GameObject LoadingScreen;
    public Slider Slider;
    
    public void LoadLevel(int SceneIndex)
    {

        StartCoroutine(LoadAsynchronously(SceneIndex));
        
    }

    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Slider.value = progress;
            yield return null;

        }

    }

}
