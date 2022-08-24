using UnityEngine;

public class Chests : MonoBehaviour
{
	[Header("Water Chests Animators")]
	[SerializeField] private Animator _waterPuzzleChest;
	[SerializeField] private Animator _waterBossChest = null;

	[Header("Earth Chests Animators")]
	[SerializeField] private Animator _earthPuzzleChest = null;
	[SerializeField] private Animator _earthBossChest = null;

	[Header("Fire Chests Animators")]
	[SerializeField] private Animator _firePuzzleChest = null;
	[SerializeField] private Animator _fireBossChest = null;

	[Space(1)]
	[Header("Game Manager")]
	[SerializeField] GameManager _gameManager;

	public void OpenWaterPuzzleChest()
	{
		_waterPuzzleChest.SetTrigger("Open");
		// weapon goes out of it then,
		// hover until,
		// the player takes it

	}
}
