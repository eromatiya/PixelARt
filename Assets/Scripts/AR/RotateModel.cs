using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {

    float RotObj = 20;

    void OnSpin()
    {

    }
    void Update()
    {
        
            float RotX = Input.GetAxis("Mouse X") * RotObj * Mathf.Deg2Rad;
            float RotY = Input.GetAxis("Mouse Y") * RotObj * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -RotX, Space.World);
            transform.Rotate(Vector3.right, -RotY, Space.World);
    }
}
