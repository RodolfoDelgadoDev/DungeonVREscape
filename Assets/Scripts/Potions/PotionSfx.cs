using UnityEngine;
using System;

/// <summary>
/// Handle the potion sfx
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PotionSfx : MonoBehaviour
{
    public static event Action OnPotionDrinkSfx;

    // CHANGE IT SO THAT I DONT NEED TO GET EVERY POTION
    // Potion sound when the player drink it
    private void PotionSfxOnDrink()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        OnPotionDrinkSfx?.Invoke();
    }
}
