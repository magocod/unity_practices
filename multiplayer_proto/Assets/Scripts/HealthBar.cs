using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class HealthBar : MonoBehaviour
{
    // [Range(0, 100)]
    [SerializeField] int _health = 100;

    [SerializeField] Slider _healthBar;

    [SerializeField] int _healAmount = 20;
    [SerializeField] int _hurtAmount = 20;

    private void Awake()
    {
        Assert.IsNotNull(_healthBar, "Health bar not set!");
    }

    private void Start()
    {
        _healthBar.value = _health;
    }

    public void Heal()
    {
        _health += _healAmount;
        _healthBar.value = _health;
        Debug.Log($"Healing {_healAmount} with result of {_healthBar.value}");
    }

    public void Hurt()
    {
        _health -= _hurtAmount;
        _healthBar.value = _health;
        Debug.Log($"Hurting {_hurtAmount} with result of {_healthBar.value}");
    }
}
