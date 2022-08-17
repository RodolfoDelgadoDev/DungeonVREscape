using UnityEngine;
using System.Text.RegularExpressions;

public class WaterRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;

	#region Properties
	private int waterRuneCount = 0;
	public int WaterRuneCount
	{
		get
		{
			return waterRuneCount;
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
				value = 3;
			}

			waterRuneCount = value;
		}
	}
	#endregion


	private void OnTriggerEnter(Collider other)
	{
		// The idea here, is to put regex so that it can take "GameObjectName" + " (anyDigit)" into account
		if (other.gameObject.name == "Rune_Water" + " (2)")
		{
			waterRuneCount += 1;
			Debug.Log("Water rune triggered");
		}
	}
}
