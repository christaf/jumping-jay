using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public LogicScript logicScript;

    public bool isAlive;

    private void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                logicScript.GameOver();
                isAlive = false;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                logicScript.RestartGame();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdRigidBody.velocity = Vector2.up * 7;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            birdRigidBody.velocity = Vector2.right * 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            birdRigidBody.velocity = Vector2.left * 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            birdRigidBody.velocity = Vector2.up * 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            birdRigidBody.velocity = Vector2.down * 2;
        }
        
        if (birdRigidBody.transform.position.y > 10 || birdRigidBody.transform.position.y < -10)
        {
            logicScript.GameOver();
            isAlive = false;
        }
        
        if(birdRigidBody.transform.position.x > 17 || birdRigidBody.transform.position.x < -17)
        {
            logicScript.GameOver();
            isAlive = false;
        }
        Debug.Log("Bird Coordinates: " + birdRigidBody.transform.position);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "BottomPipe" || col.gameObject.name == "TopPipe")
        {
            logicScript.GameOver();
            isAlive = false;
        }
    }
}