using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class OpenPDF : MonoBehaviour {

    private string bookName = "ColoringBook";
    
    public void openBook()
    {

        if (getSDKInt() > 23) {

            Application.OpenURL("http://facebook.com");
                
        }
        else
        {

            string path = System.IO.Path.Combine(Application.persistentDataPath, bookName + ".pdf");

            TextAsset pdfTemp = Resources.Load(bookName, typeof(TextAsset)) as TextAsset;
            File.WriteAllBytes(path, pdfTemp.bytes);
            Application.OpenURL(path);
        }
        
    }

    static int getSDKInt()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        using (var version = new AndroidJavaClass("android.os.Build$VERSION"))
        {
            return version.GetStatic<int>("SDK_INT");
        }
#endif
#if UNITY_EDITOR
        return 23;
#endif
    }

}
