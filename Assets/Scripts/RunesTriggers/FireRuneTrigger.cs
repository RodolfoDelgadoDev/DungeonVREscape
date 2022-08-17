using UnityEngine;

public class FireRuneTrigger : MonoBehaviour
{
	[SerializeField] RunesCount _runesCount;

	#region Properties
	private int redBookCount = 0;
	public int RedBookCount
	{
		get
		{
			return this.redBookCount;
		}
		private set
		{
			// Cannot be inferior to 0
			if (value < 0)
			{
				value = 0;
			}
			// Set limit to the red book limit variable
			else if (value > _runesCount.RedBookLimit)
			{
				value = (int)_runesCount.RedBookLimit;
			}

			this.redBookCount = value;
		}
	}
	#endregion

	// Trigger with fire runes
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rune Fire")
		{
			this.redBookCount += 1;
			// Should add like some bubbles or something that goes with watter on destroy
			Destroy(other.gameObject);
		}
	}
}
