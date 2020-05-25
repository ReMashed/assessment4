using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100; 
    //public GameObject Obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= Time.deltaTime;
    }
    //script is attached to player, so whatever it touches
    void OnTriggerEnter2D(Collider2D other) { 
        Debug.Log("touchOther");
        if (other.gameObject.name == "HealthBoost")
        {
            Destroy(other.gameObject);
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("touch");
            health += 20; 
            Debug.Log(health + "health");


        }
        if (other.gameObject.name == "SpeedBoost") {
            //gameObject.GetComponent<InputManager>().speed = gameObject.GetComponent<InputManager>().speed*2;
            gameObject.GetComponent<InputManager>().rb.velocity = new Vector2(6,0);
            Destroy(other.gameObject); 
        }
    }
}
