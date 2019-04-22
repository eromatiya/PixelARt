using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{


    public void Shot()
    {
        StartCoroutine("CRSaveScreenshot");
    }


    IEnumerator CRSaveScreenshot()
    {
        yield return new WaitForEndOfFrame();
        // string TwoStepScreenshotPath = MobileNativeShare.SaveScreenshot("Screenshot" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second);
        // Debug.Log("A new screenshot was saved at " + TwoStepScreenshotPath);

        // Wait till the last possible moment before screen rendering to hide the UI
        yield return null;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
   
        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();

        string myFileName = "PixelARt" + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".png";
        string myDefaultLocation = Application.persistentDataPath + "/" + myFileName;
		string myFolderLocation = "/storage/sdcard0/DCIM/PixelARt/";

		if (System.IO.Directory.Exists ("/storage/emulated/0/")) {
			
			myFolderLocation = "/storage/emulated/0/DCIM/PixelARt/";
		}
		if (System.IO.Directory.Exists ("/storage/sdcard0/")) {

			myFolderLocation = "/storage/sdcard0/DCIM/PixelARt/";
		}

        //string myFolderLocation = "/storage/emulated/0/DCIM/Magical/";  //EXAMPLE OF DIRECTLY ACCESSING A CUSTOM FOLDER OF THE GALLERY
        string myScreenshotLocation = myFolderLocation + myFileName;

        // Show UI after we're done
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;

        //ENSURE THAT FOLDER LOCATION EXISTS
        if (!System.IO.Directory.Exists(myFolderLocation))
        {
            System.IO.Directory.CreateDirectory(myFolderLocation);
        }

        ScreenCapture.CaptureScreenshot(myFileName);
        //MOVE THE SCREENSHOT WHERE WE WANT IT TO BE STORED

        yield return new WaitForSeconds(1);

        System.IO.File.Move(myDefaultLocation, myScreenshotLocation);

        //REFRESHING THE ANDROID PHONE PHOTO GALLERY HAS BEGUN
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_MOUNTED", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation) });
        objActivity.Call("sendBroadcast", objIntent);
        //REFRESHING THE ANDROID PHONE PHOTO GALLERY IS COMPLETE

         

    }
}