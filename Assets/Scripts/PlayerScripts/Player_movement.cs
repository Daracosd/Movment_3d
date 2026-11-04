using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class Player_movement : MonoBehaviour
{


    [Header("Movement Settings")]
    public float movementSpeed = 7f;
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private Rigidbody rb;
    private Vector2 inputVector;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //gather player input every frame
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        inputVector = new Vector2(moveX, moveY).normalized;

        
        
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection=(transform.forward*inputVector.y)+(transform.right*inputVector.x);
        rb.linearVelocity=new Vector3(moveDirection.x*movementSpeed, rb.linearVelocity.y, moveDirection.z*movementSpeed);
        
    }
}
