using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public GameObject petal;

    int level = 1;

    public double secondsUntilDropsPetal = 10;
    double minimumWaitTime = 10, subractWaitTimePerLevel = 2;
    //const int seconds

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDropsPetal -= Time.deltaTime;

        if(secondsUntilDropsPetal <= 0)
        {
            var p = Instantiate(petal, transform.position + new Vector3(0, 1, 0), new Quaternion(1, 1, 1, 1));
            p.transform.parent = gameObject.transform;
            secondsUntilDropsPetal += minimumWaitTime - level * subractWaitTimePerLevel;
        }

    }
}
