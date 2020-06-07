using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid2D;
    public float speed_x_constraint;
    public float jumppower;
    public int hp;
    public int max_hp = 0;
    public GameObject firePrefab;

    public Image hp_bar;
    void Start()
    {
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        max_hp = 10;
        hp = max_hp;

    }



    void Update()
    {
        //Movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
            rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            //this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
            rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            //this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }

        //attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(firePrefab, this.transform.position, Quaternion.identity);
        }

        //constraint
        if (rigid2D.velocity.x > speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
        }
        if (rigid2D.velocity.x < -speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
        }

        hp_bar.transform.localScale = new Vector3((float)hp / (float)max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            print(coll.gameObject.name);
            hp -= 1;
        }
            
    }
}

 