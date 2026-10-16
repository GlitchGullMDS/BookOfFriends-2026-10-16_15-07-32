using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 25f;
    [SerializeField] private ParticleSystem jumpParticles;
    [SerializeField] private AudioSource jumpSoundEffect;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private Player player;

    private float verticalVelocity;
    private bool isGrounded;

    private Rigidbody2D rigidBody;
    // For velocity based movement instead of TRANSFORMING POSITION.

    private void Start()
    {
        player = GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
        //get ref to rigidbody on player
    }

    private void Update()
    {
        CheckGrounded();

        HandleMovement();
        HandleJump();
    }


    private void HandleMovement()
    {
        float horizontalInput = GetHorizontalInput();

        UpdateRunningAnimation(horizontalInput);
        MoveHorizontally(horizontalInput);
        ApplyGravity();
        MoveVertically();
    }

    private float GetHorizontalInput()
    {
        if (player.GetPlayerNumber() == Player.PlayerNumber.Player1)
        {
            return InputManager.P1Movement.x;
        }

        if (player.GetPlayerNumber() == Player.PlayerNumber.Player2)
        {
            return InputManager.P2Movement.x;
        }

        return 0f;
    }

    private void UpdateRunningAnimation(float horizontalInput)
    {
        bool isRunning = horizontalInput != 0f;
        animator.SetBool("isRunning", isRunning);
    }

    private void MoveHorizontally(float horizontalInput)
    {
        rigidBody.linearVelocity = new Vector2(horizontalInput * moveSpeed, rigidBody.linearVelocityY);
        // For velocity based movement instead of TRANSFORMING POSITION.
    }

    private void ApplyGravity()
    {
        if (!isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        else if (verticalVelocity < 0f)
        {
            verticalVelocity = 0f;
        }
    }

    private void MoveVertically()
    {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocityX, verticalVelocity);
        // For velocity based movement instead of TRANSFORMING POSITION.
    }


    private void HandleJump()
    {
        if (!isGrounded)
            return;

        if (WasJumpPressed())
        {
            Jump();
        }
    }

    private bool WasJumpPressed()
    {
        if (player.GetPlayerNumber() == Player.PlayerNumber.Player1)
        {
            return InputManager.P1JumpWasPressed;
        }
        return false;
    }

    private void Jump()
    {
        verticalVelocity = jumpForce;
        isGrounded = false;

        jumpParticles.Play();
        jumpSoundEffect.Play();
    }


    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}