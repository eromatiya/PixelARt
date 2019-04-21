using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOutline : MonoBehaviour {
	private Color origOutline;
	private Color activeOutline;
	private GameObject oldActive;
	private Renderer tree;
	private bool isTree;
	public bool activateOutline = false;
	private int numOfChild;
	// Use this for initialization
	void Start () {
		origOutline = new Color (0f, 0f, 0f, 1f);
		activeOutline = new Color (255f, 0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (activateOutline) {

			if (Input.touchCount > 0) {
				Touch touch = Input.touches [0];
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
			
					if (oldActive != hit.collider.gameObject && oldActive != null && touch.phase == TouchPhase.Began) {

						oldActive.GetComponent<Renderer> ().material.SetColor ("_OutlineColor", origOutline);

					}

					if ((hit.collider.tag == "Sands" || hit.collider.tag == "Model") && touch.phase == TouchPhase.Began) {


						if (hit.collider.transform.childCount > 0) {
							
							OutlineTree ();
							hit.collider.transform.Find ("tree-baobab").GetComponent<Renderer> ().material.SetColor ("_OutlineColor", activeOutline);
							tree = hit.collider.transform.Find ("tree-baobab").GetComponent<Renderer> ();
							isTree = true;

						} else {

							hit.collider.gameObject.GetComponent<Renderer> ().material.SetColor ("_OutlineColor", activeOutline);
							oldActive = hit.collider.gameObject;
							OutlineTree ();
						}

					}

				}

			}

		}

	}

	public void NormalOutline(){
	
		if (oldActive) {
			oldActive.GetComponent<Renderer> ().material.SetColor ("_OutlineColor", origOutline);
			OutlineTree ();
			activateOutline = false;
		}
	}

	public void StartOutline(){
	
		activateOutline = true;
	}


	private void OutlineTree(){
		if (isTree) {
			tree.material.SetColor ("_OutlineColor", origOutline);
			isTree = false;
		}

	}

}
