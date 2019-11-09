using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composter : MonoBehaviour
{
    List<GameObject> petals = new List<GameObject>();

    public double CountDownTime = 5;
    private double timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0){

            makeCompost();
        }

    }

    private void OnTriggerEnter(Collider other){
        petals.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other){
        petals.Remove(other.gameObject);
    }

    private void makeCompost(){
        
    }
}
