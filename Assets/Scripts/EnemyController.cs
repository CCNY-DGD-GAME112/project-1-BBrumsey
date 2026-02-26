using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public float speed = 2;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver())
            return;

        if (player != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(
            rb.position, (Vector2)player.position, speed * Time.fixedDeltaTime);

            rb.MovePosition(newPosition);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.GameOver();
        }
    }
}
