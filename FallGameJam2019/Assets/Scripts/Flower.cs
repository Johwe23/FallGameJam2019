using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public GameObject petal;

    public double angle = 60;
    public int compostDropped = 0;

    int level = 1;

    public double secondsUntilDropsCompost = 10;
    double minimumWaitTime = 10, subractWaitTimePerLevel = 2;
    //const int seconds

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDropsCompost -= Time.deltaTime;

        if(secondsUntilDropsCompost <= 0)
        {
            var p = Instantiate(petal, transform.position + new Vector3(0, 1, 0), new Quaternion(1, 1, 1, 1));
            p.transform.parent = gameObject.transform;
            secondsUntilDropsCompost += minimumWaitTime - level * subractWaitTimePerLevel;
        }

    }

}
