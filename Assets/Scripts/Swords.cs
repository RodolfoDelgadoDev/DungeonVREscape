using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Hover))]
[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class Swords : MonoBehaviour
{
	[SerializeField] GameManager _gameManager;

	private bool _wasSelected = false;

	public void OnFirstSelectEntered()
	{
		if (_wasSelected == false)
		{
			// Disable Hover script
			GetComponent<Hover>().enabled = false;

			// Disable the right chest depending of the sword name
			_gameManager.chests.DisableChestSwordGrab(gameObject);

			// Remove gravity
			GetComponent<Rigidbody>().useGravity = true;

			// Remove Rigidbody constraints
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

			_wasSelected = true;
		}
	}

	public void OnSelectExited()
	{
		if (_wasSelected == true)
		{
			// Remove gravity
			GetComponent<Rigidbody>().useGravity = true;

			// Remove Rigidbody constraints
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
	}
}
