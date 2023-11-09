using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallGyro : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed = 2.0f; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        float moveX = Input.acceleration.x;
        float moveZ = Input.acceleration.y;

        
        Vector3 movement = new Vector3(-moveX, 0.0f, -moveZ);

        
       // movement.Normalize();
        //movement *= moveSpeed;

        
        rb.AddForce(movement * moveSpeed);
    }

}




