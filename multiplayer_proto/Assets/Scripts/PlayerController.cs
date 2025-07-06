using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

using Unity.Netcode;

using TMPro;


public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 3;
    public float turnSpeed = 45.0f;


    // InputAction jumpAction;
    public InputAction attackAction;

    public GameObject projectilePrefab;


    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");

    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;

        // Debug.Log("PlayerController.OnMove: x(" + movementX + ") y(" + movementY + ")");
    }

    void Update()
    {

        // Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // if (jumpAction.IsPressed())
        // {
        //     // your jump code here
        //     Debug.Log("PlayerController.Jump");
        // }

        // if (attackAction.IsPressed())
        // {
        //     // your Attack code here
        //     var instance = Instantiate(projectilePrefab);
        //     var instanceNetworkObject = instance.GetComponent<NetworkObject>();
        //     instanceNetworkObject.Spawn();

        //     Debug.Log("PlayerController.Attack");
        // }
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        // rb.AddForce(movement * speed);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * movementY);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * movementX);

        // Only execute on the Server

        // if (attackAction.IsPressed())
        // {
        //     // your Attack code here
        //     // var instance = Instantiate(projectilePrefab);
        //     // var instanceNetworkObject = instance.GetComponent<NetworkObject>();

        //     // instanceNetworkObject.Spawn();

        //     Debug.Log("PlayerController.Attack ");
        // }
    }
}
