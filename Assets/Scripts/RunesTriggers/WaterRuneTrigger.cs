using UnityEngine;

public class WaterRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;

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

	// Trigger with water runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Water")
		{
			this.waterRuneCount += 1;
			// Should add like some bubbles or something that goes with watter on destroy
			Destroy(other.gameObject);
		}
	}
}
