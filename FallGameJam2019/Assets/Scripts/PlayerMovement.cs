using System.Collections;
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
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        control.SimpleMove(new Vector3(speed * moveHorizontal, 0, speed * moveVertical));

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        if(movement.sqrMagnitude > 0.05){
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
