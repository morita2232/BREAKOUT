using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public MovimientoPelota pelota;
    public GameManager manager;
    public GameObject ballPUR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pala")
        {
            Destroy(gameObject); 

            if(pelota.choice == 0)
            {
                manager.life++;
                ballPUR = Instantiate(pelota.pelota, pelota.center, Quaternion.identity);
                ballPUR.tag = "Clon";

                SpriteRenderer sr = ballPUR.GetComponent<SpriteRenderer>();

                if(sr != null)
                {
                    sr.color = Color.red;
                } 
                
                if(ballPUR.transform.position.y <= -5.5f)
                {
                    Destroy (ballPUR);
                }

            }                

        }

        if (collision.gameObject.tag == "BordeInferior")
        {            
            Destroy(gameObject);            
        }
    }
        
}
