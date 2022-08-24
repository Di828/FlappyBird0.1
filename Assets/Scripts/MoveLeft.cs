using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float destroyZoneX = -10f;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < destroyZoneX)
            Destroy(gameObject);
    }
}
