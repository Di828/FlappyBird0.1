using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    float xPosition = 8;
    float yPosition;
    float startSpawn = 3f;
    float repeatTime = 2f;
    float obstacleYRange = 2.5f;
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startSpawn, repeatTime);
    }
    void SpawnObstacles()
    {        
        yPosition = Random.Range(-obstacleYRange, obstacleYRange);
        var spawnPosition = new Vector2(xPosition, yPosition);
        Instantiate(obstaclePrefab,spawnPosition,transform.rotation);
    }
}
