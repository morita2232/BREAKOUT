using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score;
    public TMP_Text scoreDisplay;
    public int life;
    public TMP_Text lifeDisplay;
    public GameObject pelota;

    // Update is called once per frame
    private void Update()
    {
            scoreDisplay.text = score.ToString();
            lifeDisplay.text = life.ToString();

        if (life == 0)
        {
            Debug.Log("Fin por vidas :(");
            Destroy(pelota);
        }
        if(score == 210) 
        {
            Debug.Log("Fin por puntos :)");
            Destroy(pelota);
        }
    }
}
