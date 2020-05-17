using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 movement; //2D so ignore z axis
    private bool jump;
    
    public float speed = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        MoveObject(); 
        Rotate();
    }

    void GetMovementInput(){
        //continuous values between -1, 1 
        //will need to clamp values for maintain values of 1 when diagonals occur
        movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");
        //clamping uneccessary if just horizontal movement
        //movement = Vector3.ClampMagnitude(movement, 1.0f);
        //Debug.Log(movement.sqrMagnitude); 
        jump = Input.GetButtonDown("Jump");
    }

    void MoveObject(){
        //framerate independent movement (not affected by framerate)
        //transform is object script is attached to
        //time.delta makes this framerate independent 
        if (jump != true){
            transform.position += movement * speed * Time.deltaTime;

        } else if (jump && transform.position.y <= -4 ) {
            //if player y is equal to ground level, jump is available.
            transform.Translate(Vector3.up * Time.deltaTime * 100);
            Debug.Log(transform.position.y);
        }
    }

    void Rotate(){
        //player is moving right
        if (movement.x != 0)
            {
                Debug.Log(movement.x);
                if (movement.x > 0) //if player is going right (position)
                {
                    //transform.LookAt(Vector3.right);
                    gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0,0, movement.x), Vector3.up);
               
                } else if (movement.x < 0) //if player is going left 
                {   
                    //transform.LookAt(Vector3.left);
                    gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0,0, movement.x),  Vector3.up);
                }
                
            } 
    }
}
