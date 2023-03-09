using System;

public class HealthManager
{
    /// <summary> Occurs when damage is taken </summary>
    public static event Action OnDamage;
    /// <summary> Occurs when heal is taken </summary>
    public static event Action OnHeal;

    private int _maxHealth = 6; // Change max health depending of the array size ?
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            Math.Clamp(value, 0, MaxHealth);

            _health = value;
        }
    }

    /// <summary>
    /// Used on heal
    /// </summary>
    /// <param name="healValue"></param>
    public void Heal(int healValue)
    {
        Health += healValue;
        OnHeal?.Invoke();
    }

    /// <summary>
    /// Used on damage taken
    /// </summary>
    /// <param name="damageValue"></param>
    public void Damage(int damageValue)
    {
        Health -= damageValue;
        OnDamage?.Invoke();
    }

}
