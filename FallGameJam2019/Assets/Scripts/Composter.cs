using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composter : MonoBehaviour
{
    List<GameObject> petals = new List<GameObject>();

    public double CountDownTime = 5;
    public double timer = -1;

    public GameObject compost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(timer < 0 && timer > -1){

            makeCompost();
            timer = -1;
        }
        else if(timer > 0){
            timer -= Time.deltaTime;
        }

        print(petals.Count);

    }

    private void OnTriggerEnter(Collider other){
        petals.Add(other.gameObject);
        print("Making compost...");

        if(petals.Count == 1){
            timer = CountDownTime;
        }
    }

    private void OnTriggerExit(Collider other){
        petals.Remove(other.gameObject);
    }

    private void makeCompost(){
        print("Compost made");

        for(int i = 0; i < petals.Count; i++){
            GameObject.Destroy(petals[i]);
        }

        Instantiate(compost, transform.position + new Vector3(0.9f, 0.074f, -0.855f), new Quaternion(0, 0, 0, 1));
    }
}
