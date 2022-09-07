using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunesTriggers : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;
	[SerializeField] GameObject _fire;
	[SerializeField] float _fireTime = 2.5f;

	// string: Rune tag
	// int: Rune Count
	private Dictionary<string, int> rune_TagCount = new Dictionary<string, int>();

	#region Runes Count Properties
	private int _waterRuneCount = 0;

	/// <summary>
	/// Number of Water rune triggered
	/// </summary>
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

	/// <summary>
	/// Number of Earth rune triggered
	/// </summary>
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

	/// <summary>
	/// Number of Fire rune triggered
	/// </summary>
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

	private void Awake()
	{
		rune_TagCount.Add("Rune Water", this.WaterRuneCount);
		rune_TagCount.Add("Rune Earth", this.EarthRuneCount);
		rune_TagCount.Add("Rune Fire", this.FireRuneCount);
	}

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
	private int CheckRuneTrigger(string runeTag, GameObject other)
	{
		if (other.tag == runeTag &&
			this.gameObject.tag == runeTag)
		{
			// Does not increase actual property value
			rune_TagCount[runeTag] += 1;
			Destroy(other);
			// Add sound
			StartCoroutine(FireEnableTime(_fire, _fireTime));
		}

		return rune_TagCount[runeTag];
	}

	// Trigger with runes
	private void OnTriggerEnter(Collider other)
	{
		// there is a need to do an algorithm for this part,
		// But there is not enough time

		// Check Rune Water
		this.WaterRuneCount = CheckRuneTrigger("Rune Water", other.gameObject);
		// Check Rune Earth
		this.EarthRuneCount = CheckRuneTrigger("Rune Earth", other.gameObject);
		// Check Rune Fire
		this.FireRuneCount = CheckRuneTrigger("Rune Fire", other.gameObject);
	}
}
