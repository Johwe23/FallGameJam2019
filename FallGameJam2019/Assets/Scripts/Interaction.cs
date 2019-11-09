using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private GameObject[] interactables;
    private GameObject closest;

    public float pickupRange;
    public GameObject Petal;
    public GameObject PetalTruck;
    private GameObject child = null;
    private Color colorOfPickup;
    private GameObject petal;
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

                closest = interactables[0];

                foreach (GameObject interactable in interactables)
                {
                    if ((interactable.transform.position - transform.position).sqrMagnitude < (closest.transform.position - transform.position).sqrMagnitude)
                    {
                        closest = interactable;
                    }
                }
                if ((closest.transform.position - transform.position).sqrMagnitude < pickupRange)
                {
                    Destroy(closest);
                    print("1");
                    colorOfPickup = closest.GetComponentInChildren<Renderer>().material.color;
                    print("2");
                    child = Instantiate(PetalTruck, transform);
                    child.GetComponentInChildren<Renderer>().material.SetColor("_Color", colorOfPickup);
                }
            }
            else {
                Destroy(child);
                petal = Instantiate(Petal);
                petal.GetComponentInChildren<Renderer>().material.color = colorOfPickup;
                petal.transform.position = transform.position;
            }
        }
    }
}
