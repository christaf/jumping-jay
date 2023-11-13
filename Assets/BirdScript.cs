using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public LogicScript logicScript;

    public bool isAlive;

    private void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.velocity = Vector2.up * 10;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                myRigidBody.velocity = Vector2.right * 2;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                myRigidBody.velocity = Vector2.left * 2;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidBody.velocity = Vector2.up * 2;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                myRigidBody.velocity = Vector2.down * 2;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            logicScript.GameOver();
            isAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            logicScript.RestartGame();
        }
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