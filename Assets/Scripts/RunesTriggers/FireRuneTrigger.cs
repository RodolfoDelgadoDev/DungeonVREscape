using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger fire runes
/// </summary>
public class FireRuneTrigger : MonoBehaviour
{
	[SerializeField] GameManager _gameManager;
	[SerializeField] GameObject _redFire;
	[SerializeField] float _redFireTime = 2.5f;

	#region Properties
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
			else if (value > _gameManager.runesCount.FireRuneLimit)
			{
				value = (int)_gameManager.runesCount.FireRuneLimit;
			}

			this._fireRuneCount = value;
		}
	}
	#endregion

	// Enable RedFire game object for a certain time
	// Disable it after that
	private IEnumerator WaterFireEnableTime()
	{
		_redFire.SetActive(true);

		yield return new WaitForSeconds(this._redFireTime);

		_redFire.SetActive(false);
	}

	// Trigger with fire runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Fire")
		{
			this.FireRuneCount += 1;
			Destroy(other.gameObject);
			_gameManager.addOxygen.AddSeconds(30);
			StartCoroutine(WaterFireEnableTime());
		}
	}
}
