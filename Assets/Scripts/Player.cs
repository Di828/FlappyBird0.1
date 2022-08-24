using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D playerRB;    
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
            Debug.Log("Dead");
        if (collision.CompareTag("ScoreZone"))
            Debug.Log("+1 point");
    }
}
