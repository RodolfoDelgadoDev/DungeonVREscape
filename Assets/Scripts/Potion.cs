using UnityEngine;

/// <summary>
/// Handle the potion life points system when the player drink
/// </summary>
public class Potion : MonoBehaviour
{
	[SerializeField] LifeManager _lifeManager;
	private GameObject[] _life;
	[HideInInspector] public bool drink = false;

	/// <summary>
	/// When player grab a potion,
	/// give a heart back to the player
	/// Used on Select Exited
	/// </summary>

	private void Start()
	{
		_life = _lifeManager.Life;
	}

	public void PlayerDrinkPotion()
	{
		// Potion gives back 2 Life points
		if (_life[1].activeInHierarchy == false)
		{
			_life[1].SetActive(true);
			_life[2].SetActive(true);
		}
		else if (_life[2].activeInHierarchy == false)
		{
			_life[2].SetActive(true);
			_life[3].SetActive(true);
		}
		else if (_life[3].activeInHierarchy == false)
		{
			_life[3].SetActive(true);
		}
		else
			return;

		drink = true;

		this.gameObject.SetActive(false);
	}
}
