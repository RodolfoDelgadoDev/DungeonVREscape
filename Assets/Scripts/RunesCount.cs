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


	#region Properties
	[Space(1)]
	[Header("Runes input limit")]
	[SerializeField] private uint waterRuneLimit = 3;
	public uint WaterRuneLimit { get { return waterRuneLimit; } }
	#endregion


	// Update is called once per frame
	void Update()
	{
		// numbers runes to found / number of runes to find
		_waterRuneCountText.text = $"{_waterRuneTrigger.WaterRuneCount}/{WaterRuneLimit}";
	}
}
