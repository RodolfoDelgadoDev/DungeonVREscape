using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// CountDownTimer class that defines the oxygen time
/// </summary>
public class CountDownTimer : MonoBehaviour
{
	/// <summary>
	/// Oxygen start time
	/// </summary>
	public float startTime = 90f;

	/// <summary>
	/// Oxygen count down timer
	/// </summary>
	[HideInInspector] public float timer;

	/// <summary>
	/// UI Slider
	/// </summary>
	[SerializeField] Slider slider;

	/// <summary>
	/// TimerText
	/// </summary>
	[SerializeField] TextMeshProUGUI timerText;


	/// <summary>
	/// audioTimer to handle the audiosource
	/// </summary>
	[SerializeField] AudioSource audioTimer;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Timer());
	}

	/// <summary>
	/// Timer coroutine to define the countdown
	/// </summary>
	/// <returns></returns>
	private IEnumerator Timer()
	{
		timer = startTime;

		do
		{
			timer -= Time.deltaTime;
			slider.value = timer / startTime;

			FormatText();

			yield return null;
		}
		while (timer > 0);

		if (slider.value == 0)
			SceneManager.LoadScene(2);
	}

	private void FormatText()
	{
		int seconds = (int)(timer);
		timerText.text = "";

		if (seconds > 0)
			timerText.text += seconds;

		if (seconds == (int)(startTime) / 2)
		{
			Color32 col = new Color(1.0f, 0.92f, 0.016f, 1.0f);
			timerText.color = col;
			audioTimer.Play();
		}
		else if (seconds == (int)(startTime) / 4)
		{
			timerText.color = new Color32(222, 41, 22, 255);
			audioTimer.Play();
		}
	}
}
