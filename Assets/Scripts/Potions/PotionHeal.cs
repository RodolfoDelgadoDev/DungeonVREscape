using UnityEngine;
using System;

/// <summary>
/// Handle the potion life points system when the player drink
/// </summary>
public class PotionHeal : HealthManager
{
    /// <summary> Occurs when heal is taken </summary>
    public static event Action<int> OnPotionHeal;
    private HealthManager _healthManager = new HealthManager();
    [SerializeField] private int _healAmount = 1;
    [SerializeField] private LifeManager _lifeManager;
    private GameObject[] _life;
    [HideInInspector] public bool drink = false;

    /// <summary>
    /// When player grab a potion,
    /// give a heart back to the player
    /// Used on Select Exited
    /// </summary>

    private void Start()
    {
        _life = _lifeManager.Life;
    }

    public override void Heal(int amount)
    {
        OnPotionHeal?.Invoke(amount);
        base.Heal(amount);
    }

    public void PlayerDrinkPotion()
    {

        // On drink : Heal -> heal amount
        Heal(_healAmount);
        // Gives hearts back by healAmount ex: healAmount = 1 -> + 1 heart


        // BULLSHIT CODE
        // Potion gives back 2 Life points
        /*if (_life[1].activeInHierarchy == false)
        {
            // + 2 hp
            _life[1].SetActive(true);
            _life[2].SetActive(true);
        }
        else if (_life[2].activeInHierarchy == false)
        {
            _life[2].SetActive(true);
            _life[3].SetActive(true);
        }
        else if (_life[3].activeInHierarchy == false)
        {
            // + 1 hp
            _life[3].SetActive(true);
        }
        else
            return;*/

        drink = true;

        Destroy(this.gameObject);
    }
}
