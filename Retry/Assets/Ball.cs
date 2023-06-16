using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{

    private Player player = null;

    private Rigidbody rb = null;

    //private bool shouldBallJump;

    private void Awake()
    {
        player = new Player();

        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        player.Enable();

        player.Ball.Jump.performed += OnPerformedJump;
        player.Ball.Roll.performed += OnPerformedRoll;
        //player.Ball.OrientCamera.performed += OnPerformedOrientCamera;

        player.Ball.Jump.canceled += OnCancelledJump;
        player.Ball.Roll.canceled += OnCancelledRoll;
        //player.Ball.OrientCamera.canceled += OnCancelledOrientCamera;
    }

    private void OnDisable()
    {
        player.Disable();

        player.Ball.Jump.performed -= OnPerformedJump;
        player.Ball.Roll.performed -= OnPerformedRoll;
        //player.Ball.OrientCamera.performed -= OnPerformedOrientCamera;
        
        player.Ball.Jump.canceled -= OnCancelledJump;
        player.Ball.Roll.canceled -= OnCancelledRoll;
        //player.Ball.OrientCamera.canceled -= OnCancelledOrientCamera;
    }

    // private void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.Space))
    //     // { shouldBallJump = true; }
    // }

    // private void LateUpdate()
    // {
    //     if (shouldBallJump)
    //     { Jump(5f); }
    // }

    private void Jump(float upForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(0, upForce, 0, ForceMode.VelocityChange);

        //shouldBallJump = false;
    }

    // private void Roll()
    // {
    //     //
    // }

    private void OnPerformedJump(InputAction.CallbackContext value)
    {
        Debug.Log("Jumped");

        Jump(5f);
    }

    private void OnCancelledJump(InputAction.CallbackContext value)
    {
        Debug.Log("Cancelled Jump");
    }

    private void OnPerformedRoll(InputAction.CallbackContext value)
    {

    }

    private void OnCancelledRoll(InputAction.CallbackContext value)
    {

    }
}
