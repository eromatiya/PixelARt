using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class OpenPDF : MonoBehaviour {

    private string bookName = "ColoringBook";
    
    public void openBook()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, bookName + ".pdf");

        TextAsset pdfTemp = Resources.Load(bookName, typeof(TextAsset)) as TextAsset;
        File.WriteAllBytes(path, pdfTemp.bytes);
        Application.OpenURL(path);
        
    }
}
    