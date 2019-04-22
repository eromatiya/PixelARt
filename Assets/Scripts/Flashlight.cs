using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour {

    const string pluginName = "org.artoolkit.ar.unity.UnityARPlayerActivity";

    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;

    private bool torchOn = false;

    public static AndroidJavaClass PluginClass {

        get {
            if (_pluginClass == null) {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
            return _pluginClass;
        }
    }

    public static AndroidJavaObject PluginInstance {

        get {
            if (_pluginInstance == null) {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }

    }


    private void enableFlash() {

        if (Application.platform == RuntimePlatform.Android) {

            PluginInstance.Call("turnOnFlash");
        }

    }


    private void disableFlash()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            PluginInstance.Call("turnOffFlash");
        }

    }


    public void ToggleTorch()
    {

        if (torchOn)
        {
            disableFlash();
            torchOn = false;
            Debug.Log("Torch off");
        }
        else
        {

            enableFlash();
            torchOn = true;
            Debug.Log("Torch on");
        }

    }

    public void DisableFlashOnQuit() {
        if (torchOn) {

            disableFlash();
            torchOn = false;
        }
    }

}
