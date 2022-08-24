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


	#region Properties
	[Space(1)]
	[Header("Runes Limits")]
	[SerializeField] private uint waterRuneLimit = 3;
	public uint WaterRuneLimit { get { return this.waterRuneLimit; } }

	[SerializeField] private uint earthRuneLimit = 1;
	public uint EarthRuneLimit { get { return this.earthRuneLimit; } }

	[SerializeField] private uint fireRuneLimit = 3;
	public uint FireRuneLimit { get { return this.fireRuneLimit; } }
	#endregion


	// Update is called once per frame
	void Update()
	{
		// numbers of water runes found / number of water runes to find
		_waterRuneCountText.text = $"{_gameManager.waterRuneTrigger.WaterRuneCount}/{WaterRuneLimit}";

		// numbers of earth runes found / number of earth runes to find
		_earthRuneCountText.text = $"{_gameManager.earthRuneTrigger.EarthRuneCount}/{EarthRuneLimit}";

		// numbers of fire runes found / number of fire runes to find
		_fireRuneCountText.text = $"{_gameManager.fireRuneTrigger.FireRuneCount}/{FireRuneLimit}";
	}
}
