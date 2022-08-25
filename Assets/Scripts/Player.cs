using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    bool onPlay = false;
    Rigidbody2D playerRB;
    private void Awake()
    {
        GameManager.onGameStart.AddListener(GameStart);
        GameManager.onGameOver.AddListener(GameOveR);
    }    
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onPlay)
        {
            playerRB.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
    void GameStart()
    {
        onPlay = true;
        playerRB.gravityScale = 0.8f;
    }
    void GameOveR()
    {
        onPlay = false;
        playerRB.gravityScale = 0;
        playerRB.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            GameManager.SendGameOver();
        }
        if (collision.CompareTag("ScoreZone"))
        {
            GameManager.SendScoreChanged();
        }
    }    
}
