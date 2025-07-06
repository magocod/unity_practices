using UnityEngine;

using Unity.Netcode;

[DefaultExecutionOrder(0)] // Execute before ClientNetworkTransform
public class TestSpawn : NetworkBehaviour
{
    public GameObject PrefabToSpawn;
    public bool DestroyWithSpawner;
    private GameObject m_PrefabInstance;
    private NetworkObject m_SpawnedNetworkObject;

    public override void OnNetworkSpawn()
    {

        // Only execute on the Server
        if (!IsServer)
        {
            enabled = false;

            Debug.Log("ServerFireProjectile.IsServer no");

            return;
        }

        Debug.Log("ServerFireProjectile.IsServer yes");

        // if (m_PrefabInstance == null)
        // {
            // Instantiate the GameObject Instance
            m_PrefabInstance = Instantiate(PrefabToSpawn);

            // Optional, this example applies the spawner's position and rotation to the new instance
            m_PrefabInstance.transform.position = transform.position;
            m_PrefabInstance.transform.rotation = transform.rotation;

            // Get the instance's NetworkObject and Spawn
            m_SpawnedNetworkObject = m_PrefabInstance.GetComponent<NetworkObject>();
            m_SpawnedNetworkObject.Spawn();
        // }
    }

    public override void OnNetworkDespawn()
    {
        if (IsServer && DestroyWithSpawner && m_SpawnedNetworkObject != null && m_SpawnedNetworkObject.IsSpawned)
        {
            m_SpawnedNetworkObject.Despawn();
        }
        base.OnNetworkDespawn();
    }
}
