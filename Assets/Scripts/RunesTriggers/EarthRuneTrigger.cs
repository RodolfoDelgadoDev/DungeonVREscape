using UnityEngine;

public class EarthRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;

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

	// Trigger with earth runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Earth")
		{
			this.brownBookCount += 1;
			// Should add like some bubbles or something that goes with watter on destroy
			Destroy(other.gameObject);
		}
	}
}
