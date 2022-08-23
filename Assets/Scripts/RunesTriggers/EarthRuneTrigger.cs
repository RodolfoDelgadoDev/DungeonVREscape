using UnityEngine;
using System.Collections;

public class EarthRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;
	[SerializeField] GameObject _earthFire;
	[SerializeField] float _eartFireTime = 2.5f;
	[SerializeField] GameObject[] _doors;

	#region Properties
	private int brownBookCount = 0;
	public int BrownBookCount
	{
		get
		{
			return this.brownBookCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to the red book limit variable
			else if (value > _runesCount.BrownBookLimit)
			{
				value = (int)_runesCount.BrownBookLimit;
			}

			this.brownBookCount = value;
		}
	}
	#endregion

	// Enable EarthFire game object for a certain time
	// Disable it after that
	private IEnumerator WaterFireEnableTime()
	{
		_earthFire.SetActive(true);

		yield return new WaitForSeconds(this._eartFireTime);

		_earthFire.SetActive(false);
	}

	// Trigger with earth runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Earth")
		{
			this.brownBookCount += 1;
			Destroy(other.gameObject);
			// Add sound
			StartCoroutine(WaterFireEnableTime());
			// Add sound
			if (_runesCount.BrownBookLimit == this.BrownBookCount)
			{
				foreach (GameObject go in _doors)
				{
					go.SetActive(false);
				}
			}
		}
	}
}
