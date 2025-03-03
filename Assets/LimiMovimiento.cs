using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiMovimiento : MonoBehaviour
{
    public float yMax = -1;
    public float yMin = -4.75f;
    public float xMax = 7.4f;
    public float xMin = -7.4f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yMax)
        {            
            transform.position = new Vector3(transform.position.x, yMax);
        }
        if (transform.position.y < yMin)
        {            
            transform.position = new Vector3(transform.position.x, yMin);
        }
        if (transform.position.x > xMax)
        {            
            transform.position = new Vector3(xMax, transform.position.y);
        }
        if (transform.position.x < xMin)
        {            
            transform.position = new Vector3(xMin, transform.position.y);
        }
    }
}
