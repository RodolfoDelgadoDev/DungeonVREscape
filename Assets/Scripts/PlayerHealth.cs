using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject[] playerHearts;

	// heart index
	private int _index = 0;

	/// <summary>
	/// Index of the hearts, how many
	/// heart the player has + 1
	/// </summary>
	public int Index
	{
		get
		{
			return this._index;
		}
		set
		{
			if (this._index < 0)
				value = 0;
			else if (this._index > playerHearts.Length - 1)
				value = playerHearts.Length - 1;

			this._index = value;
		}
	}

	private void Start()
	{
		// Player has full hearts
		this.Index = playerHearts.Length - 1;
	}

	/// <summary>
	/// Player lose heart when being hit,
	/// respawn at menu if no heart
	/// </summary>
	public void PlayerLoseHeart()
	{
		// When player hit
		playerHearts[Index].SetActive(false);
		Index -= 1;

		// If the player lose all hp, load MainMenu scene
		if (Index == 0)
		{
			SceneManager.LoadScene(0);
		}
	}
}
