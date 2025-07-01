using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug.Log("Start -> x:" + movementX + ", y:" + movementY);

    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;

        // Debug.Log("OnMove -> x:" + movementX + ", y:" + movementY);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 vRight = new Vector3(movementX, 0.0f, movementY);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * movementY);

        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * movementX);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * movementX);
    }
}
