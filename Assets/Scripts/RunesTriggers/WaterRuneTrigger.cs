using UnityEngine;
using System.Text.RegularExpressions;

public class WaterRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;

	private string _waterRuneRegexPattern;

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

			this.waterRuneCount = value;
		}
	}
	#endregion

	private void Start()
	{
		_waterRuneRegexPattern = @"^Rune_Water";
	}

	private void OnTriggerEnter(Collider other)
	{
		// Takes into account any game object beginning with "Rune_Water" inside its name
		if (Regex.IsMatch(other.gameObject.name, _waterRuneRegexPattern))
		{
			waterRuneCount += 1;
			// Should add like some bubbles or something that goes with watter on destroy
			Destroy(other.gameObject);
		}
	}
}
