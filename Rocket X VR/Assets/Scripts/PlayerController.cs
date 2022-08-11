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

        //obrigatorio colocar para utilizar o novo sistema de input da Unity
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
        //pegando as teclas que farao o player andar
        move = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //adicionando força e calculando a dirençao quando apertadas as teclas.
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * speed * Time.deltaTime);
    }

    private void Grav()
    {
        //Gravidade para o player nao bugar quando colidir com outro objeto (Não estou usando o Rigibody que contem a gravidade por este motivo, fiz a função)
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
  

   

}

