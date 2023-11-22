using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    
    public GameObject pipe;
    public float spawnRate = 2f;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }
    
    void SpawnPipe(float range = 2f)
    {
        Instantiate(pipe, transform.position + new Vector3(0, Random.Range(-range, range), 0), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0f;
        }
    }
}
    