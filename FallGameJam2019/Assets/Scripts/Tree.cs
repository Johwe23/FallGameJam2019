using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var color1 = ColorUtility.ToHtmlStringRGBA(other.gameObject.GetComponentInChildren<Renderer>().material.color);
        var color2 = ColorUtility.ToHtmlStringRGBA(gameObject.GetComponentInChildren<Renderer>().material.color);
        print("Entering");
        if (other.gameObject.tag == "Compost" && color1 == color2)
        {
            Destroy(other.gameObject);
        }
    }
}
