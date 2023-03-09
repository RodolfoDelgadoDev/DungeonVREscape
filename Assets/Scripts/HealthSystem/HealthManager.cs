using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
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
    /// Get the health
    /// </summary>
    /// <returns>Health</returns>
    public virtual int GetHealth()
    {
        return Health;
    }

    /// <summary>
    /// Used on heal
    /// </summary>
    /// <param name="amount">heal amount</param>
    public virtual void Heal(int amount)
    {
        Health += amount;
    }

    /// <summary>
    /// Used on damage taken
    /// </summary>
    /// <param name="amount">damage amount</param>
    public virtual void TakeDamage(int amount)
    {
        Health -= amount;
    }

}
