using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damaged)
    {
        _health -= damaged;
        HealthChanged?.Invoke(_health);

        if (_health < 0)
        {
            Die();
        }
    }

    public void PickupBonus()
    {
        if (_health < _maxHealth)
        {
            _health++;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Die()
    {
        Died?.Invoke();
        Time.timeScale = 0;
    }
}