using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public GameObject petal;
    public Color color;

    int level = 0;
    int maxLevel = 8;
    int maxDropppedPetals = 8;

    
    double minimumWaitTime = 5, subractWaitTimePerLevel = 2;
    double secondsUntilDropsPetal;
    float nextDropAngle = 0;
    float dropDistance = 0.5f;
    //const int seconds
    private string color1;
    // Start is called before the first frame update
    void Start()
    {
        upgrade();
        secondsUntilDropsPetal = minimumWaitTime;

        color1 = ColorUtility.ToHtmlStringRGBA(color);
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDropsPetal -= Time.deltaTime;

        if(secondsUntilDropsPetal <= 0)
        {
            Quaternion rotation = Quaternion.Euler(0, nextDropAngle/(2* Mathf.PI)*360 - 90, 0);

            var p = Instantiate(petal, transform.position + new Vector3(Mathf.Sin(nextDropAngle)*dropDistance, 0, Mathf.Cos(nextDropAngle)*dropDistance), rotation);
            
            p.GetComponentInChildren<Renderer>().material.SetColor("_Color", color);
            p.transform.parent = gameObject.transform;

            nextDropAngle += Mathf.PI*2/maxDropppedPetals;
            secondsUntilDropsPetal += minimumWaitTime - level * subractWaitTimePerLevel;
        }

    }

    public void upgrade(){
        
        level++;
        float angle = (float)(level)/(float)(maxLevel) * 360;

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        
        var p = Instantiate(petal, transform.position + new Vector3(0, 0.5f, 0), rotation);
        p.gameObject.tag = "Untagged";
        p.GetComponentInChildren<Renderer>().material.SetColor("_Color", color);
        p.transform.parent = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        var color2 = ColorUtility.ToHtmlStringRGBA(other.gameObject.GetComponentInChildren<Renderer>().material.color);
        if (other.gameObject.tag == "Compost" && color1 == color2) {
            upgrade();
            Destroy(other.gameObject);
        }
    }
}
