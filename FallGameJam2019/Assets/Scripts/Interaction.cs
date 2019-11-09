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

                closestPetal = interactables[0];

                foreach (GameObject interactable in interactables)
                {
                    if ((interactable.transform.position - transform.position).sqrMagnitude < (closestPetal.transform.position - transform.position).sqrMagnitude)
                    {
                        closestPetal = interactable;
                    }
                }
                interactables = GameObject.FindGameObjectsWithTag("Compost");
                
                closestCompost = interactables[0];

                foreach(GameObject interactable in interactables)
                {
                    if ((interactable.transform.position - transform.position).sqrMagnitude < (closestCompost.transform.position - transform.position).sqrMagnitude)
                    {
                        closestCompost = interactable;
                    }
                }

                if ((closestPetal.transform.position - transform.position).sqrMagnitude < (closestCompost.transform.position - transform.position).sqrMagnitude)
                {

                    if ((closestPetal.transform.position - transform.position).sqrMagnitude < pickupRange)
                    {
                        Destroy(closestPetal);
                        colorOfPickup = closestPetal.GetComponentInChildren<Renderer>().material.color;
                        child = Instantiate(PetalTruck, transform);
                        child.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                    }
                }
                else
                {
                    if ((closestCompost.transform.position - transform.position).sqrMagnitude < pickupRange)
                    {
                        Destroy(closestCompost);
                        colorOfPickup = closestCompost.GetComponentInChildren<Renderer>().material.color;
                        child = Instantiate(CompostTruck, transform);
                        child.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                    }

                }
            }
            else 
            {
                if (child.tag == "Petal")
                {
                    Destroy(child);
                    petal = Instantiate(Petal);
                    petal.transform.position = transform.position;
                    petal.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                }
                else if (child.tag == "Compost")
                {
                    Destroy(child);
                    compost = Instantiate(Compost);
                    compost.transform.position = transform.position;
                    compost.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                }
            }
        }
    }
}
