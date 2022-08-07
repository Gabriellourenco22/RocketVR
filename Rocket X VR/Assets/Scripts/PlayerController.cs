using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInputActions playerInputActions;
    private Vector2 move;
    private CharacterController controller;

    [SerializeField]private float speed;

    private Vector3 velocity;

    private float gravity = -9.81f;

    public float distanceToGround = 0.4f;

    public LayerMask groundMask;

    private bool isGrounded;

    public Transform ground;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        Grav();
    }

    private void PlayerMovement()
    {
        move = playerInputActions.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * speed * Time.deltaTime);
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
  

   

}

