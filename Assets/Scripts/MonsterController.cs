using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    int hp = 0;
    public int max_hp;
    public GameObject hp_bar;
    public enum Status{ idle, walk};
    public Status status;
    public enum Face { Right, Left };
    public Face face;

    public float speed;
    public Transform myTransform;
     
    void Start()
    {
        hp = max_hp;
        status = Status.walk;
        if (this.transform.GetComponent<SpriteRenderer>().flipX)
        {
            face = Face.Right;    
        }
        else
        {
            face = Face.Left;
        }
        myTransform = this.transform;
    }

     void Update()
    {

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        float _percent = ((float)hp / (float)max_hp);
        hp_bar.transform.localScale = new Vector3(_percent, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);

        float deltaTime = Time.deltaTime;
        //update status action
        switch (status)
        {
            case Status.idle:
                break;
            case Status.walk:
                switch(face)
                {
                    case Face.Right:
                        myTransform.position += new Vector3(speed * deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(speed * deltaTime, 0, 0);
                        break;
                }
                break;
        }
    }
   // void OnCollisionEnter2D(Collision2D coll)
    //{
      
   // }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            hp -= 1;
            Destroy(other.gameObject);
            
        }
    }
}
