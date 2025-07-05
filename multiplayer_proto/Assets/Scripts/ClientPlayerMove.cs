using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NetcodeDemo
{
    public class ClientPlayerMove : NetworkBehaviour
    {
   
        [SerializeField]
        PlayerController m_ThirdPersonController;

        [SerializeField]
        PlayerInput m_PlayerInput;

        // [SerializeField]
        // Transform m_CameraFollow;

        private void Awake()
        {
            m_PlayerInput.enabled = false;
            m_ThirdPersonController.enabled = false;
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
                m_ThirdPersonController.enabled = false;
                return;
            }

            // Enable if this is an owner
            m_PlayerInput.enabled = true;
            m_ThirdPersonController.enabled = true;

        }
    }
}