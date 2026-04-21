using UnityEngine;

/*
Player Controller:
This script handles player movement and shooting.
The player can move left and right and shoot projectiles.
*/
public class PlayerController : MonoBehaviour

{
   
    public float firingCooldown = 0.5f; //This is optional but it prevents spamming the space bar for fast tapping)
    public float nextFireTime = 0;
    public float speed = 5;
    public AudioSource shootAudio;
    public AudioClip shootSound;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10;
    private Rigidbody2D rb;
    private float HorizontalInput;
    private Vector2 input;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {

            nextFireTime = Time.time + firingCooldown;
            Shoot();
            shootAudio.PlayOneShot(shootSound);

        }

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(HorizontalInput, 0);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * projectileSpeed;
    }
}