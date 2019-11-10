using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    public Text Score;
    public Text GameOverText;
    public static float offset = 0;
    public static bool IsPaused = false;
    void Start()
    {
        GameOverText.enabled = false;
    }

    void Update()
    {
        Score.text = "Offset: " + offset;
        transform.position = new Vector3(offset, 0, 0);
        if(Mathf.Pow(offset, 2) > 16){
            GameOver();
        }
    }

    void GameOver(){
        GameOverText.enabled = true;
        Time.timeScale = 0;
        IsPaused = true;
        if(offset > 0){
            GameOverText.text = "PLAYER 1 WINS";
        } else {
            GameOverText.text = "PLAYER 2 WINS";
        }
    }
}
