using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;

    private float mouseSensitivity = 10f;
    private Vector2 mouseLook;
    private float xRotation = 0f;

    [SerializeField] private Transform playerbody;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerbody = transform.parent;
        //Fazendo cursor do mouse desaparecer da tela.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookScene();
    }

    public void LookScene()
    {
        //Lendo o input do mouse.
        mouseLook = playerInputActions.Player.MouseRotation.ReadValue<Vector2>();

        //sensibilidade (pode ser alterada conforme o jogador)
        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        //calculo de rotacao
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerbody.Rotate(Vector3.up * mouseX);
    }
}
