using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 101; 
    public Text healthText; 
    public Text instructionText;
    public GameObject speedObj;

    public Collider2D swordCollider; 


    //public SpeedBoost Obj;
    void Start()
    {
       //swordCollider = GetComponent<Collider2D>(); 
    
    }

    // Update is called once per frame
    void Update()
    {  
        if(health > 101) {
            health = 101;
        } else if (health < 1) {
            Time.timeScale = 0f; 
            instructionText.text = "Game Over \n Press R to restart";
        }
        health -= Time.deltaTime;
        healthText.text = "Health: " + (int)health; 
    }
    //script is attached to player, so whatever it touches
    void OnTriggerEnter2D(Collider2D other) { 
        //Debug.Log("touchOther");
        if (other.gameObject.name == "HealthBoost")
        {
            instructionText.text = "Touch the Lightning for a Speed Boost!";
            Destroy(other.gameObject);
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("touch");
            health += 20; 
            Debug.Log(health + "health");
        } else if (other.gameObject.name == "HealthBoost_2") {
            Destroy(other.gameObject);
            health += 20; 
            Debug.Log(health + "health");
        }
        if (other.gameObject.name == "SpeedBoost" ||other.gameObject.name == "SpeedBoost(Clone)") {
            instructionText.text = "Avoid the enemy or lose hp!";
            //gameObject.GetComponent<InputManager>().speed = gameObject.GetComponent<InputManager>().speed*2;
            //Vector2 playerCurrentVel = new Vector2(); 
            //playerCurrentVel = gameObject.GetComponent<InputManager>().rb.velocity;
            //get direction of player so they can boost left or right. 
            //gameObject.GetComponent<InputManager>().rb.velocity = new Vector2(Input.GetAxis("Horizontal")*6, 1);
            gameObject.GetComponent<InputManager>().speed = 6; //increase speed 
            StartCoroutine(speedReset());
            StartCoroutine(RespawnObject(speedObj));
            Destroy(other.gameObject); 
            //other.gameObject.GetComponent<Renderer>().enabled = false; //remove object; really just rendering
           
        }
        if (other.gameObject.name == "Step1") {
            instructionText.text = "Jump over objects with the arrow using W or Up Arrow key!";
        }
        if (other.gameObject.name == "Arrow") {
            instructionText.text = "Touch the Coffee Bean to recover your Health!";
        }
        if (other.gameObject.name == "CoffeeCup") {
            instructionText.text = "You win! \n Press R to restart";
            Time.timeScale = 0f; //freeze time so game wont run. 
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy"){
            health -= 1; 
            //print("touched enemy"); 
        }
    }
    //coroutine 
    IEnumerator RespawnObject(GameObject gameObject){
        yield return new WaitForSeconds(5);
        GameObject newObj = Instantiate(gameObject);
    }

    IEnumerator speedReset(){
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<InputManager>().speed = 3f;
    }

    
}
