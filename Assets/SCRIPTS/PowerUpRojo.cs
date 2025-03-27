/*
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
public MovimientoPelota pelota;
public GameManager manager;
public MovimientoPelota[] balls;
int ballCount;

// Start is called before the first frame update
void Start()
{
pelota = FindObjectOfType<MovimientoPelota>();
manager = FindAnyObjectByType<GameManager>();

// Find all balls currently in the scene
balls = FindObjectsOfType<MovimientoPelota>();

}

// Update is called once per frame
void Update()
{
}

private void OnTriggerEnter2D(Collider2D collision)
{
ballCount = balls.Length * 2;

if (collision.gameObject.CompareTag("Pala"))
{

if (pelota.choice == 0) // Power-up Rojo (Red Power-up)
{
manager.life++;
Instantiate(pelota.powerball[0], pelota.center, Quaternion.identity);
Destroy(gameObject);
}
else if (pelota.choice == 1) // Power-up Azul (Blue Power-up)
{
// Duplicate each ball
for (int i = 0; i < ballCount; i++)
{

GameObject newBall = Instantiate(pelota.powerball[1], pelota.center, Quaternion.identity);


}


manager.life += ballCount * 2;
Destroy(gameObject);
}
else if (pelota.choice == 2) // Power-up Verde (Green Power-up)
{
float angleStep = 30f; // Angle between each ball in the arc
float startAngle = -angleStep; // Start angle for the arc

for (int i = 0; i < 3; i++)
{
float angle = startAngle + i * angleStep;
Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

GameObject newBall = Instantiate(pelota.powerball[2], pelota.center, Quaternion.identity);

}
manager.life += 3;
Destroy(gameObject);
}
}
}

}
*/

/*
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUps : MonoBehaviour
{
    public MovimientoPelota pelota;
    public GameManager manager;
    public MovimientoPelota[] balls;
    int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        pelota = FindObjectOfType<MovimientoPelota>();
        manager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y <= -6)
        {
          Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            if (pelota.choice == 0)
            {
                manager.life++;
                Instantiate(pelota.powerball[0], pelota.center, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (pelota.choice == 1)
            {
                balls = FindObjectsOfType<MovimientoPelota>();
                ballCount = balls.Length;

                for (int i = 0; i < ballCount; i++)
                {
                    GameObject newBall = Instantiate(pelota.powerball[1], balls[i].transform.position, Quaternion.identity);

                   
                    MovimientoPelota newBallScript = newBall.GetComponent<MovimientoPelota>();
                    if (newBallScript != null)
                    {
                        newBallScript.GetComponent<Rigidbody2D>().velocity = balls[i].GetComponent<Rigidbody2D>().velocity;
                    }
                }
                manager.life += ballCount;
                Destroy(gameObject);
            }
            else if (pelota.choice == 2) 
            {
                float angleStep = 30f;
                float startAngle = -angleStep;
                

                for (int i = 0; i < 3; i++)
                {
                    float angle = startAngle + i * angleStep;
                    Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

                    GameObject newBall = Instantiate(pelota.powerball[2], pelota.center * i, Quaternion.identity);

                    
                    MovimientoPelota newBallScript = newBall.GetComponent<MovimientoPelota>();
                   
                }
                manager.life += 3;
                Destroy(gameObject);
            }
        }
    }
}
 */
using UnityEngine;

public class PowerUpRojo : MonoBehaviour
{

    public MovimientoPelota _pelota;
    public GameManager _manager;

    void Start()
    {
        _pelota = FindObjectOfType<MovimientoPelota>();
        _manager = FindObjectOfType<GameManager>();
    }

     void Update()
    {
        
        if (transform.position.y <= -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pala"))
        {
            Instantiate(_pelota.powerball[0], _pelota.center, Quaternion.identity);
            _manager.life++;
            Destroy(gameObject);
        }       

    }


}
