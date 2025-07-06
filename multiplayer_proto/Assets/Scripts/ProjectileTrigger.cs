using UnityEngine;
using Unity.Netcode;

using NetcodeDemo;

public class ProjectileTrigger : NetworkBehaviour
{

    // private void OnTriggerEnter(Collider other)
    // {
    //     // NetworkObject networkObject = other.GetComponent<NetworkObject>();
    //     // if (IsClient && networkObject != null && networkObject.IsOwner)
    //     // {
    //     //     ChangeColorServerRpc(networkObject.OwnerClientId);
    //     // }

    //     if (other.CompareTag("PlayerNet"))
    //     {
    //         Debug.Log("ProjectileTrigger.OnTriggerEnter: PlayerNet");
    //     }

    //     Debug.Log("ProjectileTrigger.OnTriggerEnter " + other.gameObject.tag);
    // }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "PlayerNet")
        {
            NetworkObject networkObject = collision.gameObject.GetComponent<NetworkObject>();

            var clientPlayerMove = collision.gameObject.GetComponent<ClientPlayerMove>();

            //If the GameObject's name matches the one you suggest, output this message in the console
            if (networkObject != null && clientPlayerMove != null)
            {
                Debug.Log("ProjectileTrigger.OnCollisionEnter: PlayerNet id - " + networkObject.OwnerClientId);
                clientPlayerMove.TakeDamage();
            }
            else
            {
                Debug.Log("ProjectileTrigger.OnCollisionEnter: PlayerNet networkObject null");
            }
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("ProjectileTrigger.OnCollisionEnter: Ground");
        }

        // Debug.Log("ProjectileTrigger.OnCollisionEnter");

    }
}
