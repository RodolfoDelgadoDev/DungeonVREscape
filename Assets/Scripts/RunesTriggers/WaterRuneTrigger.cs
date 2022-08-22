using UnityEngine;
using System.Collections;

public class WaterRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;
	[SerializeField] GameObject _waterFire;
	[SerializeField] float _waterFireTime = 2.5f;
	[SerializeField] GameObject[] _doors;

	#region Properties
	private int waterRuneCount = 0;
	public int WaterRuneCount
	{
		get
		{
			return this.waterRuneCount;
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

			this.waterRuneCount = value;
		}
	}
	#endregion

	// Enable WaterFire game object for a certain time
	// Disable it after that
	private IEnumerator	WaterFireEnableTime()
	{
		_waterFire.SetActive(true);

		yield return new WaitForSeconds(this._waterFireTime);

		_waterFire.SetActive(false);
	}

	// Trigger with water runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Water")
		{
			this.waterRuneCount += 1;
			Destroy(other.gameObject);
			// Add sound
			StartCoroutine(WaterFireEnableTime());
			// Add sound
			if (_runesCount.WaterRuneLimit == this.WaterRuneCount)
			{
				foreach (GameObject go in _doors)
				{
					go.SetActive(false);
				}
			}
		}
	}
}
