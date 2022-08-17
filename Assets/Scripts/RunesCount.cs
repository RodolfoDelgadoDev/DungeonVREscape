using UnityEngine;
using TMPro;

public class RunesCount : MonoBehaviour
{
	[Header("Runes Count")]
	[SerializeField] TMP_Text _waterRuneCountText;
	[SerializeField] TMP_Text _earthRuneCountText;
	[SerializeField] TMP_Text _fireRuneCountText;

	[Space(1)]
	[Header("Runes Triggers")]
	[SerializeField] private WaterRuneTrigger _waterRuneTrigger;
	[SerializeField] private EarthRuneTrigger _earthRuneTrigger;
	[SerializeField] private FireRuneTrigger _fireRuneTrigger;


	#region Properties
	[Space(1)]
	[Header("Input limit")]
	[SerializeField] private uint waterRuneLimit = 3;
	public uint WaterRuneLimit { get { return this.waterRuneLimit; } }

	[SerializeField] private uint brownBookLimit = 1;
	public uint BrownBookLimit { get { return this.brownBookLimit; } }

	[SerializeField] private uint redBookLimit = 3;
	public uint RedBookLimit { get { return this.redBookLimit; } }
	#endregion


	// Update is called once per frame
	void Update()
	{
		// numbers runes found / number of runes to find
		_waterRuneCountText.text = $"{_waterRuneTrigger.WaterRuneCount}/{WaterRuneLimit}";

		// numbers books found / number of books to find
		_earthRuneCountText.text = $"{_earthRuneTrigger.BrownBookCount}/{BrownBookLimit}";

		// numbers books found / number of books to find
		_fireRuneCountText.text = $"{_fireRuneTrigger.RedBookCount}/{RedBookLimit}";

		// For the following:
		// If rune count equal the limit, then, do something
	}
}
