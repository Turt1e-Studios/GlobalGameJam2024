using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform cam;
    [Header("Movement Variables")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpHeight = 3f;
    
    private CharacterController _controller;
    private Vector3 _velocity;
    private float _turnSmoothVelocity;
    private int _health;
    
    private void ResetYVelocity()
    {
        // reset y velocity if grounded
        if (_controller.isGrounded)
        {
            _velocity.y = 0f;
        }
    }

    private void RegularMovement()
    {
        // moving and turning
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        print(direction);

        if (!(direction.magnitude >= 0.1f)) return;
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle + gravity, 0f) * Vector3.forward;

        _controller.Move(moveDir * (Time.deltaTime * speed));
    }

    // Adds gravity and allows the player to jump
    private void VerticalMovement()
    {
        // jumping and gravity (from first person movement tutorial)
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
    // Start is called before the first frame update
    private void Start()
    {
        // make the cursor invisible [actually, this should probably not be in the Player script.]
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement
        ResetYVelocity();
        RegularMovement();
        VerticalMovement();
    }
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
}
