using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform groundColiderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    private bool canJump;

    private Rigidbody2D rb;  
    private bool faceRight;

    public bool FaceRight => faceRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColiderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        if(isGrounded )
        {
            canJump = true;
        }
    }
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed && canJump)
        {
            Jump(); 
            canJump = false;
        }
                
        if (Mathf.Abs(direction) > 0.01f)
        { 
            HorizontalMovement(direction); 
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayJumpSound();
        }
    }
    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            faceRight = true;
            Quaternion rot = transform.rotation;
            rot.y = 0;
            transform.rotation = rot;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            faceRight = false;
            Quaternion rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
        }
    }
}
