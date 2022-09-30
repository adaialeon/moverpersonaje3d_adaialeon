using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 5; 
    private Vector3 playerVelocity;
    public float gravity = -9.81f; 
    public bool isGrounded; 
    public Transform groundSensor;
    public LayerMask ground;
    public float sensorRadius = 0.1f;
    public float jumpForce = 5;
    public float jumpHeight = 1;
    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    // Start is called before the first frame update
    void Awake() 
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(move != Vector3.zero)
        {

            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg; 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            controller.Move(move * speed * Time.deltaTime);
        }

        //isGrounded = controller.isGrounded;

        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);

        if(isGrounded && playerVelocity.y <0)
        {
            playerVelocity.y = 0;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //playerVelocity.y += jumpForce;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);

        if(isGrounded && playerVelocity.y <0)
        {
            playerVelocity.y = 0;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //playerVelocity.y += jumpForce;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);

        if(isGrounded && playerVelocity.y <0)
        {
            playerVelocity.y = 0;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //playerVelocity.y += jumpForce;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
