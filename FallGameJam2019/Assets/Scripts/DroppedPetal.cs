using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedPetal : MonoBehaviour
{

    public double lifeTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0){
            GameObject.Destroy(gameObject);
        }
    }
}
