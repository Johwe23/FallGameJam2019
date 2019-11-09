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
                interactables = GameObject.FindGameObjectsWithTag("Interactable");

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
                    child = Instantiate(PetalTruck, transform);
                }
            }
            else {
                Destroy(child);
                petal = Instantiate(Petal);
                petal.transform.position = transform.position;
            }
        }
    }
}
