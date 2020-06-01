using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float cameraDistance = 30.0f;

    void Awake(){
        GetComponent<UnityEngine.Camera>().orthographicSize = (2.687657f); //based on inspector value
    } 

    void Update() {
        //transform is the object that the script is attached to.
        //thus itll follow player position 
        transform.position = new Vector3(player.position.x, player.position.y + 1.3298722f, transform.position.z);
    }
}
