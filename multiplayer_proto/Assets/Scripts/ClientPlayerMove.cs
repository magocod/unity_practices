using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

using System.Collections;

using Unity.Netcode.Components;

namespace NetcodeDemo
{
    public class ClientPlayerMove : NetworkBehaviour
    {

        [SerializeField]
        PlayerController m_playerController;

        [SerializeField]
        PlayerInput m_PlayerInput;

        // [SerializeField]
        // Transform m_CameraFollow;

        // For example purposes, the projectile to spawn
        public GameObject Projectile;


        // For example purposes, an offset from the weapon
        // to spawn the projectile.
        public GameObject WeaponFiringOffset;

        public float speedProjectile = 3;


        private void Awake()
        {
            m_PlayerInput.enabled = false;
            m_playerController.enabled = false;
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            enabled = IsClient; // Enable if this is a client.
            if (!IsOwner)
            {
                // Disable if this is not the owner
                enabled = false;
                m_PlayerInput.enabled = false;
                m_playerController.enabled = false;
                return;
            }

            // Enable if this is an owner
            m_PlayerInput.enabled = true;
            m_playerController.enabled = true;

        }


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

            // Vector3 brickPosition = new Vector3(2, 0, 0);

            instance.transform.position = WeaponFiringOffset.transform.position;
            // instance.transform.position = transform.position;

            instance.transform.forward = transform.forward;
            // instance.transform.rotation = instance.transform.rotation;

            // var m_Rigidbody = instance.GetComponent<NetworkRigidbody>();
            // m_Rigidbody.MovePosition(transform.forward * speedProjectile);

            instance.transform.Translate(transform.forward * Time.deltaTime * 20);

            instanceNetworkObject.Spawn();

            ProjectileSelfDestruct(instanceNetworkObject);
        }

        IEnumerator ProjectileSelfDestruct(NetworkObject instanceNetworkObject)
        {
            yield return new WaitForSeconds(1f);

            instanceNetworkObject.DontDestroyWithOwner = true;
            instanceNetworkObject.Despawn(true);
        }

        private void FixedUpdate()
        {

            // Only execute on the Server

            if (m_playerController.attackAction.IsPressed() && m_playerController.attackAction.WasPerformedThisFrame())
            {
                // your Attack code here
                // var instance = Instantiate(projectilePrefab);
                // var instanceNetworkObject = instance.GetComponent<NetworkObject>();

                // instanceNetworkObject.Spawn();

                FireWeapon();

                Debug.Log("ClientPlayerMove.Attack ");
            }
        }

        public void TakeDamage()
        {
            if (!IsOwner)
            {
                return;
            }


            if (IsServer)
            {
                Debug.Log("ClientPlayerMove.OnTakeDamage ");
                OnTakeDamage();
            }
            else
            {
                Debug.Log("ClientPlayerMove.OnTakeDamageServerRpc ");
                OnTakeDamageServerRpc();
            }
        }


        [ServerRpc]
        private void OnTakeDamageServerRpc()
        {
            OnTakeDamage();
        }


        private void OnTakeDamage()
        {

            // error setting color
            // var meshRenderer = GetComponent<MeshRenderer>();
            // var m_InstanceMaterial = new Material(meshRenderer.material);
            // meshRenderer.material = m_InstanceMaterial;

            // m_InstanceMaterial.SetColor("_BaseColor", Color.black);

            // local
            // var healtBar = gameObject.GetComponent<HealthBar>();
            // if (healtBar != null)
            // {
            //     healtBar.Hurt();
            // }

            var healtBar = gameObject.GetComponent<ClientHealthBar>();
            if (healtBar != null)
            {
                healtBar.ChangeHealthBarServerRpc(1);
            }
            

            // Debug.Log("ClientPlayerMove.OnTakeDamage ");
        }


    }
}