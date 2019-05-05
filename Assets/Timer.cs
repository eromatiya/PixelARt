using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour {

    public System.Diagnostics.Stopwatch stopwatch;

	// Use this for initialization
	void Start () {
        //stopwatch = System.Diagnostics.Stopwatch.StartNew();
        //stopwatch.Stop();
        //Debug.Log(stopwatch.Elapsed.TotalSeconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void StartCounting(){
	
		stopwatch = System.Diagnostics.Stopwatch.StartNew();

	}

	public void StopCounting(){
	

		stopwatch.Stop();
		Debug.LogWarning(stopwatch.Elapsed.TotalSeconds);
	}
}
