using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;
    //public Plane other;
    public float speed;
    public string PlayerNumber;
    public float maxDashTime = 0.1f;      ////
    //public float dashDistance = 10;
    //public float dashStoppingSpeed = 0.1f;
    float currentDashTime = 0;
    public float dashSpeed = 15;                        ////
    public AudioSource Source;
    public AudioClip Sound;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //other.move(1); 
        Source.clip = Sound;                                                                              //#########################################
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("P" + PlayerNumber + "Horizontal");
        float moveVertical = Input.GetAxisRaw("P" + PlayerNumber + "Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if ((transform.position.x < Plane.offset) && PlayerNumber == "1"){              // fast on left
            control.SimpleMove(speed * movement.normalized);
            if(Input.GetButtonDown("P" + PlayerNumber + "Dash")){
                currentDashTime = 0;
                //Dash(movement.normalized);
                Source.Play();

            }
        } else if ((transform.position.x > Plane.offset) && PlayerNumber == "2") {      // fast on right
            control.SimpleMove(speed * movement.normalized);
            if(Input.GetButtonDown("P" + PlayerNumber + "Dash")){
                currentDashTime = 0;
                //Dash(movement.normalized);
                Source.Play();
            }
        } else {
            control.SimpleMove(0.5f * speed * movement.normalized);
        }
        print("Plane offset: " + Plane.offset);

        if(currentDashTime < maxDashTime) {
                    control.SimpleMove(dashSpeed * movement.normalized);
                    currentDashTime += Time.deltaTime;
                }

        if(movement.sqrMagnitude > 0){
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
    void Dash(Vector3 direction)
    {
        currentDashTime = 0;
        while(currentDashTime < maxDashTime) {
            control.SimpleMove(dashSpeed * direction);
            currentDashTime += Time.deltaTime;
        }
        /*
        if (Input.GetButtonDown(KeyCode.Z)){
            currentDashTime = 0.0f;
        }

        if (currentDashTime < MaxDashTime){
            moveDirection = new vector3(0, 0, dashSpeed);
            currentDashTime += dashStoppingSpeed;
        } else {
            moveDirection = vector3.zero;
        }
        control.Move(direction*Time.deltaTime); ////
        */
    }
    
}