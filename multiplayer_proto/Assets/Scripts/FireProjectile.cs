using UnityEngine;
using UnityEngine.InputSystem;

public class FireProjectile : MonoBehaviour
{
    // Only GameObjects with a Rigidbody can be assigned as the projectile.
    public Rigidbody projectile;
    // Speed of the projectile when fired.
    // This is a public variable so it can be adjusted in the Unity Editor.
    public float speed = 4;
    // Update is called once per frame
    // This method checks for input and fires a projectile if the attack action is pressed.
    void Update()
    {
        // Check if the "Attack" action was pressed this frame
        // If it was, instantiate a projectile at the player's position and set its velocity.
        if (InputSystem.actions.FindAction("Attack").WasPressedThisFrame())
        {
            Vector3 brickPosition = new Vector3(2, 1, 0);
            // Vector3 position = new Vector3(transform.position.x, 1, transform.position.z);

            // Rigidbody p = Instantiate(projectile, transform.position + brickPosition, transform.rotation);
            // Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody p = Instantiate(projectile, transform.position, projectile.transform.rotation);
            p.linearVelocity = transform.forward * speed;
        }
    }
}