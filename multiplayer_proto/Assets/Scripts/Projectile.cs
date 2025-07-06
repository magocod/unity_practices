using UnityEngine;

// https://docs.unity3d.com/6000.1/Documentation/Manual/instantiating-prefabs-projectiles.html

public class Projectile : MonoBehaviour
{

    // public GameObject explosion;

    void Start()
    {
        // Deletes the projectile after 10 seconds, regardless
        // of whether it collided with anything. This prevents
        // instances from staying in the scene indefinitely.
        // Destroy(gameObject, 10);
    }

    void OnCollisionEnter()
    {
        // When the projectile hits something, create an explosion
        // and remove the projectile.
        // Instantiate(explosion,transform.position,transform.rotation);
        // Debug.Log("Projectile.OnCollisionEnter");

        // Destroy(gameObject);
    }
}
