using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class ScaleModel : MonoBehaviour {

   
    /*
    [Range(2, 6)]
    public float x = 2;
    [Range(2, 6)]
    public float y = 2;
    [Range(2, 6)]
    public float z = 2;
    */
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    /*
    void Update (float x, float y, float z) {
        transform.localScale = new Vector3(x, y, z);
    }
    */


    public void Scale(float scaleValue)
    {
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void Rotate(float rotateValue)
    {
        transform.localEulerAngles = new Vector3(0, rotateValue, 0);
    }
    
    
}
