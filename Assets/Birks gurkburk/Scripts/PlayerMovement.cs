using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D body;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] GameObject aimTarget;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        body.linearVelocity = new Vector2(horizontalInput, verticalInput) * movementSpeed * Time.deltaTime;

        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        aimTarget.transform.position = transform.position + (Vector3)direction * 1f;
        transform.up = aimTarget.transform.position - transform.position;
    }

    
}
