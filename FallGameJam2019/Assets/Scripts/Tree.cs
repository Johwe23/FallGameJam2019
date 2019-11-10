using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public int player;

    public static float offsetIncreasePerTurn = 0.05f;
    public static float offsetIncrease = 0.5f;
    Color[] colors = {
        Color.red,
        Color.blue, 
        new Color(1, 1, 0, 1), //yellow
        Color.green,
        new Color(0.682127f, 0, 1, 1), //purple
        new Color(1, 0.6249813f, 0, 1), //Orange
    };
    public AudioClip upsound;
    public AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        changeColor();
        Source.clip = upsound;
        
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
            Source.Play();
        }
    }

    private void changeColor(){
        gameObject.GetComponentInChildren<Renderer>().material.color = colors[(int)Mathf.Floor(Random.Range(0, 6))];
    }

    private void upgrade(){

        if(player == 1){
            Plane.offset += offsetIncrease;
        }
        else{
            Plane.offset -= offsetIncrease;
        }

        offsetIncrease += offsetIncreasePerTurn;

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees){
            tree.GetComponent<Tree>().updateSize();
        }

        
        changeColor();
    }

    public void updateSize(){
        if(player == 1){
            transform.localScale = new Vector3(2, 2, 2) * (18 + Plane.offset)/18;
        }
        else{
            transform.localScale = new Vector3(2, 2, 2) * (18 - Plane.offset)/18;
        }
    }
}
