using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Hover))]
[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class Swords : MonoBehaviour
{
	[SerializeField] GameManager _gameManager;

	private bool _wasSelected = false;

	/// <summary>
	/// Used for the first grab of the sword when it goes out
	/// of the chest
	/// </summary>
	public void OnFirstSelectEntered()
	{
		// Condition for the script to work only once per sword
		if (_wasSelected == false)
		{
			// Disable Hover script
			GetComponent<Hover>().enabled = false;

			// Disable the right chest depending of the sword name
			_gameManager.chests.DisableChestSwordGrab(this.gameObject);

			// Use gravity
			GetComponent<Rigidbody>().useGravity = true;

			// Remove Rigidbody constraints
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

			_wasSelected = true;
		}

	}

	/// <summary>
	/// Used for when the sword is ungrabbed
	/// </summary>
	public void OnSelectExited()
	{
		// Use gravity
		GetComponent<Rigidbody>().useGravity = true;

		// Remove Rigidbody constraints
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	}
}
