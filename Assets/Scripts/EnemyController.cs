using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public float speed = 2;
    private Rigidbody2D rb;
    public ParticleSystem blood;
    public ParticleSystem playerBlood;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private AudioClip zombieGroan;
    public AudioSource zombieAudio;
    public AudioClip walkSound;

    public void Die()
    {
        if(blood != null)
        {
            ParticleSystem bloodEffect = Instantiate(blood, transform.position, Quaternion.identity);
            bloodEffect.Play();
        }

        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        if (GameManager.Instance != null)
            GameManager.Instance.AddScore(1);

        FindFirstObjectByType<SpawnManager>()?.OnZombieKilled();

        Destroy(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
        

        if (zombieAudio != null && walkSound != null)
        {
            zombieAudio.clip = walkSound;
            zombieAudio.loop = true;
            zombieAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
       
        if (player != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, (Vector2)player.position, speed * Time.fixedDeltaTime);

            rb.MovePosition(newPosition);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInParent<PlayerController>() != null)
        {
            if (playerBlood != null)
            {
                ParticleSystem playerEffect = Instantiate(playerBlood, collision.transform.position, Quaternion.identity);
                playerEffect.Play();
            }

            Destroy(collision.gameObject);

            if (GameManager.Instance != null)
                GameManager.Instance.GameOver();

            if (zombieAudio != null)
                zombieAudio.Stop();
        
        }
    }
}
