using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class ClientHealthBar : NetworkBehaviour
{
    public NetworkVariable<int> m_NetworkHealth = new NetworkVariable<int>(0);

    [SerializeField] int _health = 100;

    [SerializeField] Slider _healthBar;

    // [SerializeField] int _healAmount = 20;
    [SerializeField] int _hurtAmount = 20;


    public override void OnNetworkSpawn()
    {
        m_NetworkHealth.OnValueChanged += OnHealthChanged;

        _healthBar.value = _health;
    }

    public override void OnNetworkDespawn()
    {
        m_NetworkHealth.OnValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int oldHealth, int newHealth)
    {
        UpdateHealthBar(newHealth);
    }
    
    private void UpdateHealthBar(int newHealth)
    {
        _health -= _hurtAmount;
        _healthBar.value = _health;
        Debug.Log($"Hurting {_hurtAmount} with result of {_healthBar.value}");
    }


    [Rpc(SendTo.Server)]
    public void ChangeHealthBarServerRpc(ulong amount)
    {
        m_NetworkHealth.Value += 1;
    }
}

