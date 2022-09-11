using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
	[SerializeField] PlayerHealth _playerHealth;

	/// <summary>
	/// When player grab a potion,
	/// give a heart back to the player
	/// Used on Select Exited
	/// </summary>
	public void PlayerDrinkPotion()
	{
		// If player is already full health, do nothing
		if (_playerHealth.Index == _playerHealth.playerHearts.Length - 1)
		{
			return;
		}

		// Add particles and vfx
		_playerHealth.Index += 1;
		_playerHealth.playerHearts[_playerHealth.Index].SetActive(true);
		this.gameObject.SetActive(false);
	}
}
