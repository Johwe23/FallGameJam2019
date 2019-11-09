using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    float offset = 0;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    public void move(float dist)
    {
        offset += dist;
    }
}
