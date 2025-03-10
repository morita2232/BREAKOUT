using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public MovimientoPelota pelota;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        pelota = FindObjectOfType<MovimientoPelota>();
        manager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pala" && pelota.choice == 0)
        {
            manager.life++;
            Instantiate(pelota.powerball[0], pelota.center, Quaternion.identity);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Pala" && pelota.choice == 1)
        {

            Instantiate(pelota.powerball[1], pelota.center, Quaternion.identity);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Pala" && pelota.choice == 2)
        {
            manager.life += 3;
            Instantiate(pelota.powerball[2], pelota.center, Quaternion.identity);
            Destroy(gameObject);

        }
    }
        
}
