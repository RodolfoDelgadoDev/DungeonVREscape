using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Chests : MonoBehaviour
{
	[Header("Chests Animators")]
	[SerializeField] private Animator _waterPuzzleChest;
	[SerializeField] private Animator _waterBossChest = null;

	[SerializeField] private Animator _earthPuzzleChest = null;
	[SerializeField] private Animator _earthBossChest = null;

	[SerializeField] private Animator _firePuzzleChest = null;
	[SerializeField] private Animator _fireBossChest = null;

	[Space(1)]
	[Header("Check Runes Found")]
	[SerializeField] private RunesCount _runesCount;
	[SerializeField] private WaterRuneTrigger _waterRuneTrigger;
	[SerializeField] private EarthRuneTrigger _earthRuneTrigger;
	[SerializeField] private FireRuneTrigger _fireRuneTrigger;

	// Update is called once per frame
	void Update()
	{
		if (_runesCount.WaterRuneLimit == _waterRuneTrigger.WaterRuneCount)
		{
			// Make the chest appear and when the player interact with the chest,
			// open the chest

			_waterPuzzleChest.gameObject.transform.parent.gameObject.SetActive(true); // Chest appear
			//Interact
			//_waterPuzzleChest.SetTrigger("Open"); // Open the chest
		}
	}
}
