using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// LifeManager class that defines the health to the player
/// </summary>
public class LifeManager : MonoBehaviour
{

	/// <summary>
	/// Array that have all the characters of LIFE
	/// </summary>
	public GameObject[] Life;


	/// <summary>
	/// Give Inmortality to the player after getting hit
	/// </summary>
	private bool _isImmortal = false;

	private void Start()
	{
		Life[3].SetActive(false);
		Life[2].SetActive(false);
		Life[1].SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" && _isImmortal == false)
		{
			if (Life[3].activeInHierarchy == true)
				Life[3].SetActive(false);
			else if (Life[2].activeInHierarchy == true)
				Life[2].SetActive(false);
			else if (Life[1].activeInHierarchy == true)
				Life[1].SetActive(false);
			else if (Life[0].activeInHierarchy == true)
			{
				Life[0].SetActive(false);
				SceneManager.LoadScene(0);
			}
			_isImmortal = true;
			StartCoroutine(Immortality());
		}
	}

	IEnumerator Immortality()
	{
		yield return new WaitForSeconds(3f);
		_isImmortal = false;
	}
}
