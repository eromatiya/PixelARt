﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotPreview : MonoBehaviour
{

    [SerializeField]
    GameObject panel;
    string[] files = null;
    int whichScreenShotIsShown = 0;

    // Use this for initialization
    void Start()
    {
		string myFolderLocation = "/storage/sdcard0/DCIM/PixelARt/";

		if (System.IO.Directory.Exists ("/storage/emulated/0/")) {

			myFolderLocation = "/storage/emulated/0/DCIM/PixelARt/";
		}
		if (System.IO.Directory.Exists ("/storage/sdcard0/")) {

			myFolderLocation = "/storage/sdcard0/DCIM/PixelARt/";
		}


        files = Directory.GetFiles(myFolderLocation, "*.png");
        if (files.Length > 0)
        {
            GetPictureAndShowIt();
        }
    }

    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        panel.GetComponent<Image>().sprite = sp;
    }

    Texture2D GetScreenshotImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public void NextPicture()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShown += 1;
            if (whichScreenShotIsShown > files.Length - 1)
                whichScreenShotIsShown = 0;
            GetPictureAndShowIt();
        }
    }

    public void PreviousPicture()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShown -= 1;
            if (whichScreenShotIsShown < 0)
                whichScreenShotIsShown = files.Length - 1;
            GetPictureAndShowIt();
        }
    }
}
