using UnityEngine;

public class Hover : MonoBehaviour
{
	[SerializeField] private float _waveAmplitude = 0.1f, _waveFrequency = 1f;
	private float startYPosition;

	private void Start()
	{
		startYPosition = transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		float y = Mathf.Sin(Time.time * _waveFrequency) * _waveAmplitude;



		transform.localPosition = new Vector3(transform.position.x, startYPosition + y, transform.position.z);
	}
}
