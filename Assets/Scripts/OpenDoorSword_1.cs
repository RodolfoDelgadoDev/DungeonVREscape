using System.Collections;
using UnityEngine;

public class OpenDoorSword_1 : MonoBehaviour
{
	[SerializeField] AudioSource _openDoorSfx;
	[SerializeField] GameObject _openDoor;
	[SerializeField] GameObject _swordHint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ColliderSwordHit")
		{
			StartCoroutine(SwordOpenDoor());
		}
	}

	private IEnumerator SwordOpenDoor()
	{
		_openDoorSfx.Play();

		yield return new WaitForSeconds(_openDoorSfx.clip.length);

		_swordHint.SetActive(false);
		_openDoor.SetActive(false);
		this.transform.parent.gameObject.SetActive(false);
	}
}
