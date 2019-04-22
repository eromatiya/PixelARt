using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOutline : MonoBehaviour
{
    private GameObject oldActive;
    public bool activateOutline = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activateOutline)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if ( oldActive && touch.phase == TouchPhase.Began)
                    {

                        if (oldActive.transform.childCount < 1)
                        {
                            oldActive.GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.black);
                        }
                        else
                        {

                            foreach (Renderer r in oldActive.GetComponentsInChildren<Renderer>())
                            {

                                r.material.SetColor("_OutlineColor", Color.black);
                            }

                        }


                    }

                    if ((hit.collider.tag == "Sands" || hit.collider.tag == "Model") && touch.phase == TouchPhase.Began)
                    {


                        if (hit.collider.gameObject.transform.childCount == 0)
                        {
                            hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.red);
                            oldActive = hit.collider.gameObject;
                        }
                        else
                        {

                            foreach (Renderer r in hit.collider.gameObject.GetComponentsInChildren<Renderer>())
                            {

                                r.material.SetColor("_OutlineColor", Color.red);

                            }
                            oldActive = hit.collider.gameObject;

                        }

                    }

                }

            }

        }

    }

    public void NormalOutline()
    {

        if (oldActive)
        {
            if (oldActive.transform.childCount < 1)
            {
                oldActive.GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.black);
            }
            else
            {

                foreach (Renderer r in oldActive.GetComponentsInChildren<Renderer>())
                {

                    r.material.SetColor("_OutlineColor", Color.black);
                }

            }


        }
    }

    public void StartOutline()
    {

        activateOutline = true;
    }

    

}
