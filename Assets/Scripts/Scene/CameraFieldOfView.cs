using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//attached to gizmo camera
public class CameraFieldOfView : MonoBehaviour {

    private Camera gizCam;

    void Start () {
        //gameObject.GetComponent<Camera>().CopyFrom(Camera.main);

        gizCam = gameObject.GetComponent<Camera>();

        /*
        gizCam.CopyFrom(Camera.main);
        gizCam.depth = 3;
        gizCam.cullingMask = 1 << LayerMask.NameToLayer("AR_Gizmos"); //| 1 << LayerMask.NameToLayer("AR_Trackables");
        gizCam.clearFlags = CameraClearFlags.Depth;
        */
    }

    // Update is called once per frame
    void Update () {
        gizCam.CopyFrom(Camera.main);
        gizCam.depth = 3;
        gizCam.cullingMask = 1 << LayerMask.NameToLayer("AR_Gizmos"); //| 1 << LayerMask.NameToLayer("AR_Trackables");
        gizCam.clearFlags = CameraClearFlags.Depth;

    }
}
