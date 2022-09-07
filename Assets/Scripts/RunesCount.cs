using UnityEngine;
using TMPro;

public class RunesCount : MonoBehaviour
{
	[Header("Runes Count")]
	[SerializeField] TMP_Text _waterRuneCountText;
	[SerializeField] TMP_Text _earthRuneCountText;
	[SerializeField] TMP_Text _fireRuneCountText;

	[Space(1)]
	[Header("Game Manager")]
	[SerializeField] private GameManager _gameManager;


	#region Runes Limits Properties
	[Space(1)]
	[Header("Runes Limits")]
	[SerializeField] private uint _waterRuneLimit = 3;
	public uint WaterRuneLimit { get { return this._waterRuneLimit; } }

	[SerializeField] private uint _earthRuneLimit = 1;
	public uint EarthRuneLimit { get { return this._earthRuneLimit; } }

	[SerializeField] private uint _fireRuneLimit = 3;
	public uint FireRuneLimit { get { return this._fireRuneLimit; } }
	#endregion


	// Update is called once per frame
	void Update()
	{
		// numbers of water runes found / number of water runes to find
		_waterRuneCountText.text = $"{_gameManager.runesTriggers.WaterRuneCount}/{WaterRuneLimit}";

		// numbers of earth runes found / number of earth runes to find
		_earthRuneCountText.text = $"{_gameManager.runesTriggers.EarthRuneCount}/{EarthRuneLimit}";

		// numbers of fire runes found / number of fire runes to find
		_fireRuneCountText.text = $"{_gameManager.runesTriggers.FireRuneCount}/{FireRuneLimit}";
	}

	/// <summary>
	/// If all water runes are found,
	/// makes the water chest appear
	/// </summary>
	/// <param name="waterPuzzleChest"></param>
	public void WaterRunesFound(GameObject waterPuzzleChest)
	{
		if (waterPuzzleChest.activeSelf)
			return;

		if (_gameManager.runesTriggers.WaterRuneCount == WaterRuneLimit)
		{
			waterPuzzleChest.SetActive(true);
		}
	}

	/// <summary>
	/// If all earth runes are found,
	/// makes the earth chest appear
	/// </summary>
	/// <param name="earthPuzzleChest"></param>
	public void EarthRunesFound(GameObject earthPuzzleChest)
	{
		if (earthPuzzleChest.activeSelf)
			return;

		if (_gameManager.runesTriggers.EarthRuneCount == EarthRuneLimit)
		{
			earthPuzzleChest.SetActive(true);
		}
	}

	/// <summary>
	/// If all fire runes are found,
	/// makes the fire chest appear
	/// </summary>
	/// <param name="firePuzzleChest"></param>
	public void FireRunesFound(GameObject firePuzzleChest)
	{
		if (firePuzzleChest.activeSelf)
			return;

		if (_gameManager.runesTriggers.FireRuneCount == FireRuneLimit)
		{
			firePuzzleChest.SetActive(true);
		}
	}

	/// <summary>
	/// Check if the correct runes are found
	/// Did not work correctly, so not used
	/// </summary>
	/// <param name="puzzleChest"></param>
	/// <param name="runeCountProperty"></param>
	/// <param name="runeLimitProperty"></param>
	public void RunesFound(GameObject puzzleChest, int runeCountProperty, uint runeLimitProperty)
	{
		if (puzzleChest.activeSelf)
			return;

		if (runeCountProperty == runeLimitProperty)
		{
			puzzleChest.SetActive(true);
		}
	}
}
