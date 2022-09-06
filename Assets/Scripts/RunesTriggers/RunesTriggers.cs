using UnityEngine;
using System.Collections;

public class RunesTriggers : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;
	[SerializeField] GameObject _fire;
	[SerializeField] float _fireTime = 2.5f;

	#region Runes Count Properties
	private int _waterRuneCount = 0;
	public int WaterRuneCount
	{
		get
		{
			return this._waterRuneCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to the water rune limit variable
			else if (value > _runesCount.WaterRuneLimit)
			{
				value = (int)_runesCount.WaterRuneLimit;
			}

			this._waterRuneCount = value;
		}
	}

	private int _earthRuneCount = 0;
	public int EarthRuneCount
	{
		get
		{
			return this._earthRuneCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to the earth rune limit limit variable
			else if (value > _runesCount.EarthRuneLimit)
			{
				value = (int)_runesCount.EarthRuneLimit;
			}

			this._earthRuneCount = value;
		}
	}

	private int _fireRuneCount = 0;
	public int FireRuneCount
	{
		get
		{
			return this._fireRuneCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to fire rune limit variable
			else if (value > _runesCount.FireRuneLimit)
			{
				value = (int)_runesCount.FireRuneLimit;
			}

			this._fireRuneCount = value;
		}
	}
	#endregion

	// Enable Fire game object for a certain time
	// Disable it after that
	private IEnumerator FireEnableTime(GameObject fire, float fireTime)
	{
		fire.SetActive(true);

		yield return new WaitForSeconds(fireTime);

		fire.SetActive(false);
	}

	// Check the rune it is triggering with, increase the value by 1
	// for each rune and start the fire animation
	// Used in OnTriggerEnter
	private void CheckRuneTrigger(string runeTag, int runeCountProperty, GameObject other)
	{
		if (other.tag == runeTag &&
			this.gameObject.tag == runeTag)
		{
			Destroy(other);
			// Add sound
			StartCoroutine(FireEnableTime(_fire, _fireTime));
		}
	}

	// Trigger with runes
	private void OnTriggerEnter(Collider other)
	{
		// Check Rune Water
		CheckRuneTrigger("Rune Water", this.WaterRuneCount++, other.gameObject);
		// Check Rune Earth
		CheckRuneTrigger("Rune Earth", this.EarthRuneCount++, other.gameObject);
		// Check Rune Fire
		CheckRuneTrigger("Rune Fire", this.FireRuneCount++, other.gameObject);
	}
}
