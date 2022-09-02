using System.Collections;
using UnityEngine;

/// <summary>
/// Hovering the canvases.
/// </summary>
public class Hover : MonoBehaviour
{
	[SerializeField] private float _waveAmplitude = 0.1f, _waveFrequency = 1f;
	private float startYPosition;

	private void Start()
	{
		// Get the Y position at start
		startYPosition = transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		Hovering(_waveFrequency, _waveAmplitude);
	}

	/// <summary>
	/// Makes an object hover, used in update
	/// </summary>
	/// <param name="go">Game Object to hover</param>
	/// <param name="waveFrequency">The wave time frequency</param>
	/// <param name="waveAmplitude">The wave amplitude</param>
	public void Hovering(float waveFrequency, float waveAmplitude)
	{
		float y = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
		// Hovering
		transform.localPosition = new Vector3(transform.position.x, startYPosition + y, transform.position.z);
	}
}
