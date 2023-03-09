using UnityEngine;
using System;

public class PlayerHealth : HealthManager
{
    private void OnEnable()
    {
        PotionHeal.OnPotionHeal += base.Heal;
    }

    private void OnDisable()
    {
        PotionHeal.OnPotionHeal -= base.Heal;
    }
}
