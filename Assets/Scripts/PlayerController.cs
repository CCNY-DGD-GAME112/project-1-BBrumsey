using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public Rigidbody2D RB;
  
    public float speed = 5;
    public float HorizontalInput;
    public float VerticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       


    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");


    }
}
