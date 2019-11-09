using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static float offset = 0;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        //move(0.5f - Random.value);
        if (Input.GetButtonDown("P1Interact")) {
            move(1);
        }
        */
    }

    public void move(float dist)
    {
        offset += dist;
        transform.Translate(dist, 0, 0);
    }
    
}
