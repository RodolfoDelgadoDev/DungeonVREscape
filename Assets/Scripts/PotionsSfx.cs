using UnityEngine;

/// <summary>
/// Handle the potions sfx
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PotionsSfx : MonoBehaviour
{
	[SerializeField] Potion[] _potions;

	private void Update()
	{
		PotionSound();
	}

	// Potion sound when the player drink it
	private void PotionSound()
	{
		foreach (Potion potion in _potions)
		{
			if (potion != null && potion.drink == true)
			{
				potion.drink = false;
				this.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}
}
