using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Chests : MonoBehaviour
{
	#region Chests Animators Variables
	[Header("Water Chests Animators")]
	[SerializeField] private Animator _waterPuzzleChest;
	[SerializeField] private Animator _waterBossChest = null;

	[Header("Earth Chests Animators")]
	[SerializeField] private Animator _earthPuzzleChest = null;
	[SerializeField] private Animator _earthBossChest = null;

	[Header("Fire Chests Animators")]
	[SerializeField] private Animator _firePuzzleChest = null;
	[SerializeField] private Animator _fireBossChest = null;
	#endregion

	[Space(1)]
	[Header("Chest Sounds")]
	[SerializeField] private AudioSource _spawnChest = null;
	[SerializeField] private AudioSource _openChest;

	[Space(1)]
	[Header("Game Manager")]
	[SerializeField] private GameManager _gameManager;

	[Space(1)]
	[Header("Swords")]
	[SerializeField] private GameObject _waterSword;
	[SerializeField] private GameObject _earthSword;
	[SerializeField] private GameObject _fireSword;
	[SerializeField] private float _swordUpSpeed = 0.07f;

	private void Update()
	{
		_gameManager.runesCount.WaterRunesFound(_waterPuzzleChest.gameObject.transform.parent.gameObject);

		// Move water sword up if the sword game object is active
		if (_waterSword.activeSelf)
			MoveWaterSword();
	}

	/// <summary>
	/// Activates when the player trigger the water puzzle chest
	/// </summary>
	public void OpenWaterPuzzleChest()
	{
		// Open chest animation
		_waterPuzzleChest.SetTrigger("Open");
		// Chest sound for treasure
		_openChest.enabled = true;
		// makes the sword appear
		_waterSword.SetActive(true);
	}

	// Move the water sword when the chest is opened
	private void MoveWaterSword()
	{
		if (_waterSword.transform.position.y >= 1.1f)
			return;

		_waterSword.transform.position += transform.up * _swordUpSpeed * Time.deltaTime;
	}

	// Find chest spawn sound, like wood sound or heavy wood sound or something popping
	// Still need for water sword:
	// Sword to hover when it finishes going up
	// Sword to be grabbed by the handle
	// Cut the sound smoothly (like the sound going down bit by bit) when the word is grabbed
	// Make the chest disappear once the player has taken the sword
}
