using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composter : MonoBehaviour
{
    public double CountDownTime = 4f;
    public double timer = -1f;
    public RectTransform timeBar;

    private Color yellow = new Color(1, 1, 0, 1);

    public GameObject compost;
    public AudioClip Sound;
    public AudioSource Source;
    // Start is called before the first frame update
    void Start()
    {
        Source.clip = Sound;
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
            timeBar.sizeDelta = new Vector2(20, (float)(timer/CountDownTime)*50);
        }

        Collider collider =  gameObject.GetComponent<Collider>();
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents);

        List<GameObject> petals = new List<GameObject>();
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Petal"){
                petals.Add(hitColliders[i].gameObject);
            }
            i++;
        }

        if(petals.Count == 0){
            timer = -1;
            timeBar.sizeDelta = new Vector2(20, (float)(timer/CountDownTime)*50);
            return;
        }

    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "Petal"){
            timer = CountDownTime;
            Source.Play();
        }
        
    }

    private void makeCompost(){

        GameObject c = Instantiate(compost, transform.position + transform.rotation * new Vector3(-0.85f, 0, 0.855f), new Quaternion(0, 0, 0, 1));

        Collider collider =  gameObject.GetComponent<Collider>();
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents);


        List<GameObject> petals = new List<GameObject>();

        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Petal"){
                petals.Add(hitColliders[i].gameObject);
            }
            i++;
        }

        if(petals.Count == 0){
            timer = -1;
            return;
        }

        Color color1 = petals[0].GetComponentInChildren<Renderer>().material.color;
        Color cColor = color1;

        if(petals.Count > 1){


            Color color2 = petals[1].GetComponentInChildren<Renderer>().material.color;

            if(color1 == Color.blue && color2 == Color.red || color2 == Color.blue && color1 == Color.red){
                cColor = new Color(0.682127f, 0, 1, 1);
            }
            else if(color1 == yellow && color2 == Color.red || color2 == yellow && color1 == Color.red){
                cColor = new Color(1, 0.357038f, 0, 1);
            }
            else if(color1 == yellow && color2 == Color.blue || color2 == yellow && color1 == Color.blue){
                cColor = Color.green;
            }
        }
        c.GetComponentInChildren<Renderer>().material.color = cColor;

        for(int j = 0; j < petals.Count; j++){
            GameObject.Destroy(petals[j]);
        }
    }
}
