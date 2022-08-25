using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float destroyZoneX = -10f;
    bool onPlay;
    private void Awake()
    {
        onPlay = true;
        GameManager.onGameOver.AddListener(GameOver);
    }
    void Update()
    {
        if (onPlay)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < destroyZoneX)
                Destroy(gameObject);
        }
    }    
    public void GameOver()
    {
        onPlay = false;
    }
}
