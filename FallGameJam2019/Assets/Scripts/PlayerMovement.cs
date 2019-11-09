﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;

    public float speed;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("P1Horizontal");
        float moveVertical = Input.GetAxisRaw("P1Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        control.SimpleMove(speed * movement.normalized);
        
        if(movement.sqrMagnitude > 0){
            transform.rotation = Quaternion.LookRotation(movement);
        }

        print(Input.GetButton("P1Interact"));
    }
}
