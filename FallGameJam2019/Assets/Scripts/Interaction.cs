using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private GameObject[] interactables;
    private GameObject closestPetal;
    private GameObject closestCompost;

    public float pickupRange;
    public GameObject Petal;
    public GameObject PetalTruck;
    public GameObject Compost;
    public GameObject CompostTruck;
    private GameObject child = null;
    private Color colorOfPickup;
    private GameObject petal;
    private GameObject compost;
    public string PlayerNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P"+PlayerNumber+"Interact")){
            if (child == null)
            {
                interactables = GameObject.FindGameObjectsWithTag("Petal");

                if (interactables.Length>0) {

                    closestPetal = interactables[0];

                    foreach (GameObject interactable in interactables)
                    {
                        if ((interactable.transform.position - transform.position).sqrMagnitude < (closestPetal.transform.position - transform.position).sqrMagnitude)
                        {
                            closestPetal = interactable;
                        }
                    }
                }
                interactables = GameObject.FindGameObjectsWithTag("Compost");

                if (interactables.Length > 0)
                {
                    closestCompost = interactables[0];

                    foreach (GameObject interactable in interactables)
                    {
                        if ((interactable.transform.position - transform.position).sqrMagnitude < (closestCompost.transform.position - transform.position).sqrMagnitude)
                        {
                            closestCompost = interactable;
                        }
                    }

                }

                if (closestPetal == null || closestCompost == null) {
                    if (closestPetal != null && closestCompost == null) {
                        pickUp(closestPetal);
                    } else if (closestPetal == null && closestCompost != null)
                    {
                        pickUp(closestCompost);
                    }
                }
                else if ((closestPetal.transform.position - transform.position).sqrMagnitude < (closestCompost.transform.position - transform.position).sqrMagnitude)
                {
                    pickUp(closestPetal);   
                }
                else
                {
                    pickUp(closestCompost);
                }
            }
            else 
            {
                if (child.tag == "Petal")
                {
                    Destroy(child);
                    petal = Instantiate(Petal);
                    petal.transform.position = transform.position;
                    petal.transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up *-90);
                    petal.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                }
                else if (child.tag == "Compost")
                {
                    Destroy(child);
                    compost = Instantiate(Compost);
                    compost.transform.position = transform.position;
                    compost.transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up * -90);
                    compost.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                }
            }
        }
    }

    private void pickUp(GameObject item) {
        if ((item.transform.position - transform.position).sqrMagnitude < pickupRange)
        {
            colorOfPickup = item.GetComponentInChildren<Renderer>().material.color;
            if (item.tag == "Petal")
            {
                child = Instantiate(PetalTruck, transform);
            } else if (item.tag == "Compost")
            {
                child = Instantiate(CompostTruck,transform);
            }
            Destroy(item);
            child.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
        }
    }
}
