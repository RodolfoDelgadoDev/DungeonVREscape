using System.Collections;
using UnityEngine;

public class OpenDoorSword_1 : MonoBehaviour
{
	private int _openDoorSword_1 = 0, _openDoorSword_2 = 0;
	[SerializeField] AudioSource _openDoorSound;
	[SerializeField] GameObject _openDoor;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "OpenDoorSword_1")
		{
			_openDoorSword_1 += 1;
			Debug.Log("enter1: " + _openDoorSword_1);
		}
		if (other.tag == "OpenDoorSword_2")
		{
			_openDoorSword_2 += 1;
			Debug.Log("enter2: " + _openDoorSword_2);
		}


		if (_openDoorSword_2 == 1 && _openDoorSword_1 == 1)
			StartCoroutine(SwordOpenDoor());
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "OpenDoorSword_1")
		{
			_openDoorSword_1 -= 1;
			Debug.Log("exit1: " + _openDoorSword_1);
		}
		if (other.tag == "OpenDoorSword_2")
		{
			_openDoorSword_2 -= 1;
			Debug.Log("exit2: " + _openDoorSword_2);
		}
	}

	private IEnumerator SwordOpenDoor()
	{
		Debug.Log("Couritine");
		_openDoorSound.Play();

		yield return new WaitForSeconds(_openDoorSound.clip.length);

		_openDoor.SetActive(false);
		this.gameObject.SetActive(false);
	}
}
