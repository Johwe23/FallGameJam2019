using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPetal : MonoBehaviour
{
    public float deathTime;
    private float currentTime;
    public float shrinkTime;
    private float passedTime;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Petal") {
            Destroy(gameObject, deathTime);
            currentTime = 0f;
            passedTime = shrinkTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Petal")
        {
            if (currentTime > deathTime-shrinkTime)
            {
                passedTime -= Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1) * passedTime / shrinkTime;
            }
            currentTime += Time.deltaTime;
        }
    }
}
