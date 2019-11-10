using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    Color[] colors = {
        Color.red,
        Color.blue, 
        new Color(1, 1, 0, 1), //yellow
        Color.green,
        new Color(0.682127f, 0, 1, 1), //purple
        new Color(1, 0.6249813f, 0, 1), //Orange
    };

    public int player;
    // Start is called before the first frame update
    void Start()
    {
        changeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var color1 = ColorUtility.ToHtmlStringRGBA(other.gameObject.GetComponentInChildren<Renderer>().material.color);
        var color2 = ColorUtility.ToHtmlStringRGBA(gameObject.GetComponentInChildren<Renderer>().material.color);
        
        if (other.gameObject.tag == "Compost" && color1 == color2)
        {
            upgrade();
            Destroy(other.gameObject);
        }
    }

    private void changeColor(){
        gameObject.GetComponentInChildren<Renderer>().material.color = colors[(int)Mathf.Floor(Random.Range(0, 6))];
    }

    private void upgrade(){
        transform.localScale = transform.localScale * 1.1f;
        if(player == 1){
            Plane.offset += 0.5f;
        }
        else{
            Plane.offset -= 0.5f;
        }

        changeColor();
    }
}
