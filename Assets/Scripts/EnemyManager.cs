using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float xPos;
    private float prevMin; 
    private float prevMax;
    public Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        vec = transform.position; 
        xPos = vec.x; 
        prevMin = vec.x;
        prevMax = vec.x; 
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(0, Random.Range(-2.0f, 2.0f));
        vec.x = (xPos + (float)0.8*Mathf.Sin(2*Time.time));
        transform.position = vec;
        //print(vec.x);
        if (vec.x > prevMax) {
            prevMax = vec.x;
            //print(prevMax + "max");
        } else if (vec.x < prevMin) {
            prevMin = vec.x; 
            //print(prevMin + "prevMin");
        }
        
        //https://answers.unity.com/questions/59934/how-to-an-object-floating-up-and-down.html
        if (vec.x > 19.09 && vec.x < 19.11) {
            //transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            transform.right = new Vector3(18.31f, -0.1f, 0.0f) - transform.position;
            //rb.velocity = transform.right * 3; 
        } else if (vec.x < 17.515 && vec.x > 17.51) {
            //transform.Rotate(0.0f, 360.0f, 0.0f, Space.Self);
            //transform.right = -transform.right; 
            //rb.velocity = -transform.right * 3;
            transform.right = new Vector3(18.31f, -0.1f, 0.0f) - transform.position;
        }
    }
  
}
