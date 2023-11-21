using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyRigidBody.transform.position.y < -10)
        {
            enemyRigidBody.velocity = Vector2.up * 20;
        }else if (enemyRigidBody.transform.position.y > 10)
        {
            enemyRigidBody.velocity = Vector2.down * 20;
        }
    }
}