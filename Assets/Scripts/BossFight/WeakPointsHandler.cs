using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// WeakPointsHandler class that defines the damage from the player
/// </summary>
public class WeakPointsHandler : MonoBehaviour
{
	/// <summary>
	/// array of hearths
	/// </summary>
	public GameObject[] hearths;


	private int count = 0;

	/// <summary>
	/// boss gameobject
	/// </summary>
	public GameObject boss;

	/// <summary>
	/// door gameObject to open when the boss is dead
	/// </summary>
	public GameObject doorOnDeath;

	/// <summary>
	/// bossMusic to disable when the battle ends
	/// </summary>
	public GameObject spawnMusic;

	/// <summary>
	/// battleMusic
	/// </summary>
	public GameObject battleMusic;

	[SerializeField] GameManager _gameManager;
	[SerializeField] GameObject _swordHint;

	public GameObject slashSound;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sword")
		{
			Vector3 vel = other.gameObject.GetComponent<Rigidbody>().velocity;
			if (vel.magnitude >= 2)
			{
				foreach (var heart in hearths)
				{
					if (heart.activeInHierarchy == true)
					{
						heart.SetActive(false);
						if (count == 2)
							count++;
						break;
					}
					else
						count++;
				}
				if (count == 3)
				{
					doorOnDeath.SetActive(false);

					spawnMusic.SetActive(true);
					spawnMusic.GetComponent<AudioSource>().Play();

					battleMusic.GetComponent<AudioSource>().Stop();
					battleMusic.SetActive(false);

					StartCoroutine(_gameManager.SmokeOnDisable(boss));
					_swordHint.SetActive(true);
					_gameManager.addOxygen.AddSeconds(60);
					boss.SetActive(false);
				}
				slashSound.GetComponent<AudioSource>().Play();
				this.gameObject.SetActive(false);
			}
		}
	}
}
