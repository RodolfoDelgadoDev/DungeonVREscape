using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager healthManager { get; private set; }
    public PlayerHealth playerHealth;

    void Awake()
    {
        // Check it there is more than 1 instance
        if (healthManager != null && healthManager != this)
        {
            Destroy(this);
        }
        // Singleton
        else
        {
            healthManager = this;
        }
    }
}
