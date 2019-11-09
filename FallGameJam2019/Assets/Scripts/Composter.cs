using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composter : MonoBehaviour
{
    List<GameObject> petals = new List<GameObject>();

    public double CountDownTime = 10;
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

    }

    private void OnTriggerEnter(Collider other){
        petals.Add(other.gameObject);

        if(petals.Count == 1){
            timer = CountDownTime;
        }
    }

    private void OnTriggerExit(Collider other){
        petals.Remove(other.gameObject);
    }

    private void makeCompost(){


        GameObject c = Instantiate(compost, transform.position + new Vector3(0.9f, 0.074f, -0.855f), new Quaternion(0, 0, 0, 1));

        Color color1 = petals[0].GetComponentInChildren<Renderer>().material.color;
        Color cColor = color1;

        if(petals.Count > 1){
            
            Color color2 = petals[1].GetComponentInChildren<Renderer>().material.color;

            
            if(color1 == Color.blue && color2 == Color.red || color2 == Color.blue && color1 == Color.red){
                cColor = new Color(136, 3, 252);
            }
            else if(color1 == Color.yellow && color2 == Color.red || color2 == Color.yellow && color1 == Color.red){
                cColor = new Color(252, 152, 3);
            }
            else if(color1 == Color.yellow && color2 == Color.blue || color2 == Color.yellow && color1 == Color.blue){
                cColor = Color.green;
            }
        }
        c.GetComponentInChildren<Renderer>().material.color = cColor;


        for(int i = 0; i < petals.Count; i++){
            GameObject.Destroy(petals[i]);
        }

        
    }
}
