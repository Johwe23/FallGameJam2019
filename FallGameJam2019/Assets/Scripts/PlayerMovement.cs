using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;
    //public Plane other;
    public float speed;
    public string PlayerNumber;

    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //other.move(1);                                                                               //#########################################
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("P" + PlayerNumber + "Horizontal");
        float moveVertical = Input.GetAxisRaw("P" + PlayerNumber + "Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if ((transform.position.x < Plane.offset) && PlayerNumber == "1"){              // slow on right
            control.SimpleMove(speed * movement.normalized);
        } else if ((transform.position.x > Plane.offset) && PlayerNumber == "2") {      // slow on left
            control.SimpleMove(speed * movement.normalized);
        } else {
            control.SimpleMove(0.5f * speed * movement.normalized);
        }
        print("Plane offset: " + Plane.offset);

        if(movement.sqrMagnitude > 0){
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}