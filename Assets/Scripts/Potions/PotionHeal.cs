using UnityEngine;

/// <summary>
/// Represents the potion healing system
/// </summary>
public class PotionHeal : MonoBehaviour
{
    [SerializeField] private int _healAmount = 1;

    /// <summary>
    /// When player grab a potion,
    /// give a heart back to the player
    /// Used on Select Exited
    /// </summary>

    private void OnEnable()
    {
        PotionSfx.OnPotionDrinkSfx += PlayerDrinkPotion;
    }

    private void OnDisable()
    {
        PotionSfx.OnPotionDrinkSfx -= PlayerDrinkPotion;
    }

    /// <summary>
    /// Player drink a healing potion
    /// </summary>
    public void PlayerDrinkPotion()
    {
        HealthManager.healthManager.playerHealth.Heal(_healAmount);

        Destroy(this.gameObject);
    }
}
