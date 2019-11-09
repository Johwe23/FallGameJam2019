using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //CharacterController characterController;

    public CharacterController cont;

    public float speed = 6.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cont.SimpleMove(new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical")));
        //print(Input.GetAxis("Horizontal"));
        Vector2 facing = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).Angle; 
        transform.eulerAngles = (0f, facing, 0f);
    }
}
