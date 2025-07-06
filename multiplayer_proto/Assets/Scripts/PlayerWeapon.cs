using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Client-Server Spawning
/// Pseudo player weapon that is assumed to be
/// attached to a fixed child node of the player.
/// (i.e. like a hand node or the like)
/// </summary>
public class PlayerWeapon : NetworkBehaviour
{
    // For example purposes, the projectile to spawn
    public GameObject Projectile;


    // For example purposes, an offset from the weapon
    // to spawn the projectile.
    public GameObject WeaponFiringOffset;


    public void FireWeapon()
    {
        if (!IsOwner)
        {
            return;
        }


        if (IsServer)
        {
            OnFireWeapon();
        }
        else
        {
            OnFireWeaponServerRpc();
        }
    }


    [ServerRpc]
    private void OnFireWeaponServerRpc()
    {
        OnFireWeapon();
    }


    private void OnFireWeapon()
    {
        var instance = Instantiate(Projectile);
        var instanceNetworkObject = instance.GetComponent<NetworkObject>();
        instance.transform.position = WeaponFiringOffset.transform.position;
        instance.transform.forward = transform.forward;
        instanceNetworkObject.Spawn();
    }
}
