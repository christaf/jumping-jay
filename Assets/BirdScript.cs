using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D myRigidBody;

    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * 10;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody.velocity = Vector2.right * 10;
        }
    }
}