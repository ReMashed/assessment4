using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{   
    private Vector3 movement; //2D so ignore z axis
    private bool jump;
    private bool attack; 
    private RaycastHit2D hit; 
    //private bool canDoubleJump = false; 
    private bool started = false; 
    

    public float speed = 3f; 
    public Rigidbody2D rb; 
    public Animator animator; //Animations will probs go in seperate script later
    public LevelManager scManager; 
    
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        scManager = GetComponent<LevelManager>();
        Time.timeScale = 0.0f; 
    }

    // Update is called once per frame
    void Update()
    {   
        //When player moves unpause game
        if (Input.GetButtonDown("Horizontal") && started == false) {
            Time.timeScale = 1.0f;
            started = true; 
        }

        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale == 0) {
            scManager.LoadA(0);
        }
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 10);
        //Debug.Log(hit.distance + "distance from collider");
        //Debug.DrawRay(transform.position, dwn*10, Color.red, 0.5f);
        //Debug.Log("collider hit" + hit.collider);
        //Debug.Log(rb.velocity);
        GetMovementInput();
        MoveObject(); 
        Rotate();
    }

    public void GetMovementInput(){
        //continuous values between -1, 1 
        //will need to clamp values for maintain values of 1 when diagonals occur
        movement.x = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Vertical"); //jump should be instant
        attack = Input.GetKeyDown("space");
        //clamping uneccessary if just horizontal movement
        //movement = Vector3.ClampMagnitude(movement, 1.0f);
        //Debug.Log(movement.sqrMagnitude); 
        //jump = Input.GetButtonDown("Jump");
    }

    public void MoveObject(){
        //framerate independent movement (not affected by framerate)
        //transform is object script is attached to
        //time.delta makes this framerate independent
                
        if (!(jump) && movement.x != 0){
            transform.position += movement * speed * Time.deltaTime;
            //if (hit.distance < 0.6){
            animator.SetTrigger("Run"); //trigger running animation.
            Attack();
            
            //}
        } else if (jump) {
            //if touching ground. 
            animator.SetTrigger("Jump");
            if (hit.distance < 0.6) {
                rb.velocity = new Vector2(0, 7);
                //canDoubleJump = true; 
            } /*
            else {
                if (canDoubleJump) {
                canDoubleJump = false; 
                rb.velocity = new Vector2(0, 7);
                 } 
            } */
        }
        else {
            //when player stops moving set back to idle
            //Debug.Log(hit.distance);
            animator.SetTrigger("Idle");
            Attack(); 
            }
    }

    public void Rotate(){
        //player is moving right
        if (movement.x != 0)
            {
                //Debug.Log(movement.x); 
                if (movement.x > 0) //if player is going right (position)
                {
                    //transform.LookAt(Vector3.right);
                    //up direction is y axis hence vector3.up
                    gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0,0, movement.x), Vector3.up);
               
                } else if (movement.x < 0) //if player is going left 
                {   
                    //transform.LookAt(Vector3.left);
                    gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0,0,movement.x ),  Vector3.up);
                }     
            } 
    }

    public void Attack(){
        if (attack){
                animator.SetTrigger("Attack");
                gameObject.GetComponent<PlayerManager>().swordCollider.enabled = true; 
                gameObject.GetComponent<PlayerManager>().energy -= 10;  
            } else {

                if(animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime && !animator.IsInTransition(0)) {
                    //gameObject.GetComponent<PlayerManager>().swordCollider.enabled = false; 
                }
                
                
                
            }
       

    }
}
