using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    [SerializeField]
    float mousesensitivity = 2f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation;


    public Transform player;
    

    GameObject Me;
    //Rigidbody rgBody;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(moveDirection * _speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(moveDirection * _speed * Time.deltaTime * 10);
        }


    }
}
