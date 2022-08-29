using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject cloudsPrefab;
    float xPosition = 10;
    float yPosition;
    float startSpawn = 3f;
    float timeObstacles;
    float repeatTimeObstacles = 2f;
    float repeatTimeClouds = 35f;
    float timeClouds = 0;
    float obstacleYRange = 2.5f;
    float xPositionClouds = 19;
    float yCloudsRange = 0.5f;
    bool onPlay = false;
    private void Awake()
    {
        GameManager.onGameStart.AddListener(StartGame);
        GameManager.onGameOver.AddListener(GameOver);
        SpawnPlayer();        
        timeObstacles = startSpawn;
    }
    private void Update()
    {
        if (onPlay)
        {
            if (timeObstacles <= 0)
            {
                SpawnObstacle();
                timeObstacles = repeatTimeObstacles;
            }
            else
                timeObstacles -= Time.deltaTime;
            if (timeClouds <= 0)
            {
                SpawnClouds();
                timeClouds = repeatTimeClouds;
            }
            else
                timeClouds -= Time.deltaTime;
        }            
    }
    void StartGame()
    {
        onPlay = true;
    }
    void GameOver()
    {        
        onPlay = false;
    }
    void SpawnObstacle()
    {        
        yPosition = Random.Range(-obstacleYRange, obstacleYRange);
        var spawnPosition = new Vector2(xPosition, yPosition);
        Instantiate(obstaclePrefab,spawnPosition,transform.rotation);
    }
    void SpawnClouds()
    {
        yPosition = Random.Range(-yCloudsRange, yCloudsRange);
        var spawnPosition = new Vector2(xPositionClouds, 0);
        Instantiate(cloudsPrefab, spawnPosition, transform.rotation);
    }
    void SpawnPlayer()
    {
        var spawnPosition = new Vector2(-6, 0);
        var player = Instantiate(GameManager.Instance.birdsList[GameManager.selectedBirdNumber], spawnPosition,
            GameManager.Instance.birdsList[GameManager.selectedBirdNumber].transform.rotation);
        player.transform.localScale = Vector3.one * 1.5f;
    }
}
