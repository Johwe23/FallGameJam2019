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
        transform.position = new Vector3(offset, 0, 0);
    }
}
