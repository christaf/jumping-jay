using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

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