using UnityEngine;

/// <summary>
/// Handle the potions sfx
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PotionsSfx : MonoBehaviour
{
    [SerializeField] PotionHeal[] _potions;

    private void Update()
    {
        PotionSound();
    }

    // CHANGE IT SO THAT I DONT NEED TO GET EVERY POTION
    // Potion sound when the player drink it
    private void PotionSound()
    {
        foreach (PotionHeal potionHeal in _potions)
        {
            if (potionHeal != null && potionHeal.drink == true)
            {
                potionHeal.drink = false;
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
