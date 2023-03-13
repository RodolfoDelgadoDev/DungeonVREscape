using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 4;
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        // Debug.Log($"Starting health / MaxHealth : {MaxHealth}");
        // Debug.Log($"CurrentHealth : {CurrentHealth}");
    }

    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(1);
            Debug.Log($"DAMAGE : MaxHealth : {MaxHealth}, CurrentHealth : {CurrentHealth}");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Heal(1);
            Debug.Log($"HEAL : MaxHealth : {MaxHealth}, CurrentHealth : {CurrentHealth}");
        }*/

        // Debug.Log($"MaxHealth : {MaxHealth}, CurrentHealth : {CurrentHealth}");
    }

    /// <summary>
    /// Get the current health
    /// </summary>
    /// <returns>CurrentHealth</returns>
    public int GetHealth()
    {
        return CurrentHealth;
    }

    /// <summary>
    /// Used on heal
    /// </summary>
    /// <param name="amount">heal amount</param>
    public void Heal(int amount)
    {
        CurrentHealth += amount;
    }

    /// <summary>
    /// Used on damage taken
    /// </summary>
    /// <param name="amount">damage amount</param>
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
    }
}
