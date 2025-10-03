
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // Settings
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 3f;
    //[SerializeField] private bool _canJump = true;
    [SerializeField] private bool _isGrounded = true;

    [SerializeField] private Rigidbody2D _rb;
    private float _horizontalMovement;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_horizontalMovement * _speed, _rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded == true)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    // Grounded check 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
