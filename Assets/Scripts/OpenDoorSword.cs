using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Open doors when the player's sword collide with
/// the sword hint collider
/// </summary>
public class OpenDoorSword : MonoBehaviour
{
	[SerializeField] AudioSource _openDoorSfx;
	[SerializeField] GameObject _openDoor;
	[SerializeField] GameObject _swordHint;
	[SerializeField] GameObject _oxygenCanvas;

	// Triggers when the sword and hint sword colliders collides
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ColliderSwordHint")
		{
			StartCoroutine(SwordOpenDoor());
		}
	}

	// Play the opening door sound, deactivate
	// the sword hint game object and door game object,
	// deactivate the sword used to do it
	private IEnumerator SwordOpenDoor()
	{
		_openDoorSfx.Play();

		yield return new WaitForSeconds(_openDoorSfx.clip.length);

		if (_openDoor.name == "ExitDoor")
		{
			SceneManager.LoadScene(3);
		}

		_swordHint.SetActive(false);
		_openDoor.SetActive(false);
		this.transform.parent.gameObject.SetActive(false);
	}
}
