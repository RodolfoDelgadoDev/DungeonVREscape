using UnityEngine;

/// <summary>
/// Add oxygen time to the player
/// </summary>
public class AddOxygen : MonoBehaviour
{
	[SerializeField] GameManager _gameManager;

	/// <summary>
	/// Add seconds to the oxygen timer
	/// </summary>
	public void AddSeconds(int seconds)
	{
		_gameManager.countDownTimer.timer += seconds;
		_gameManager.countDownTimer.startTime += seconds;
	}
}
