using UnityEngine;
using System.Collections;

public class EarthRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;
	[SerializeField] GameObject _earthFire;
	[SerializeField] float _earthFireTime = 2.5f;
	[SerializeField] GameObject[] _doors;

	#region Properties
	private int earthRuneCount = 0;
	public int EarthRuneCount
	{
		get
		{
			return this.earthRuneCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to the red book limit variable
			else if (value > _runesCount.EarthRuneLimit)
			{
				value = (int)_runesCount.EarthRuneLimit;
			}

			this.earthRuneCount = value;
		}
	}
	#endregion

	// Enable EarthFire game object for a certain time
	// Disable it after that
	private IEnumerator WaterFireEnableTime()
	{
		_earthFire.SetActive(true);

		yield return new WaitForSeconds(this._earthFireTime);

		_earthFire.SetActive(false);
	}

	// Trigger with earth runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Earth")
		{
			this.earthRuneCount += 1;
			Destroy(other.gameObject);
			// Add sound
			StartCoroutine(WaterFireEnableTime());
			// Add sound
			if (_runesCount.EarthRuneLimit == this.EarthRuneCount)
			{
				foreach (GameObject go in _doors)
				{
					go.SetActive(false);
				}
			}
		}
	}
}
