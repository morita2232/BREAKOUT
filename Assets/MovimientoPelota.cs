using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPelota : MonoBehaviour
{
    //public GameManager manager;
    public float speed;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = Random.Range(-1f, 1f);
        if (horizontal < 0f) horizontal = -1f;
        else horizontal = 1f;
        vertical = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = new Vector3(horizontal, vertical).normalized;

        transform.position += direccion * speed * Time.deltaTime;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "BordeSuperior")
        {
            vertical *= -1f;
        }
        if (collision.gameObject.tag == "Pala")
        {
            
            Vector3 dir = transform.position - collision.transform.position;

            dir.Normalize();

            horizontal = dir.x;
            vertical = dir.y;
        }
        
        if (collision.gameObject.tag == "BordeLateralIzquierdo")
        {                        
            horizontal *= -1f;            
        }
        if (collision.gameObject.tag == "BordeLateralDerecho")
        {            
            horizontal *= -1f;            
        } 
        if(collision.gameObject.tag == "Bloque")
        {
           Vector3 dir = transform.position - collision.transform .position;

            dir.Normalize();

            horizontal = dir.x;
            vertical = dir.y;

            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "BordeInferior")
        {
            Spawn();
        }

    }

    void Spawn()
    {
        transform.position = new Vector3(0, (float)-1.50, 0);

        horizontal = Random.Range(-1f, 1f);
        if (horizontal < 0f) horizontal = -1f;
        else horizontal = 1f;
        vertical = -1f;
    }
}
