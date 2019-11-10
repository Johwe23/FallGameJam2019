using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    public Text score;
    public static float offset = 0;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = "Offset: " + offset;
        
        if (Input.GetButtonDown("P1Interact")) {
            move(1);
        } else if (Input.GetButtonDown("P2Interact")) {
            move(-1);
        }
    }

    public void move(float dist)
    {
        offset += dist;
        transform.Translate(dist, 0, 0);
    }
    
}
