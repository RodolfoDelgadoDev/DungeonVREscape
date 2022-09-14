using UnityEngine;
using System.Collections;

/// <summary>
/// Handle the chests
/// </summary>
public class Chests : MonoBehaviour
{
	#region Variables
	#region Chests Variables
	[Header("Puzzle Chests Animators")]
	[SerializeField] Animator _waterPuzzleChestAnimator;
	[SerializeField] Animator _earthPuzzleChestAnimator;
	[SerializeField] Animator _firePuzzleChestAnimator;

	[Space(1)]
	[Header("Chests Sounds")]
	[SerializeField] private AudioSource _openChestSfx;
	#endregion

	[Space(1)]
	[Header("Game Manager")]
	[SerializeField] private GameManager _gameManager;

	[Space(1)]
	[Header("Swords")]
	[SerializeField] private GameObject _waterSword;
	[SerializeField] private GameObject _earthSword;
	[SerializeField] private GameObject _fireSword;

	private bool _waterChestOpened = false;
	private bool _earthChestOpened = false;
	private bool _fireChestOpened = false;
	#endregion

	private void Update()
	{
		ChestSpawn();
	}

	// Check if the runes are found
	// And makes the corresponding chest appear
	private void ChestSpawn()
	{
		if (_waterChestOpened == false)
		{
			// Makes water chest appear when the water runes are found
			_gameManager.runesCount.WaterRunesFound(_waterPuzzleChestAnimator.gameObject.transform.parent.gameObject);
		}

		if (_earthChestOpened == false)
		{
			// Makes earth chest appear when the runes are found
			_gameManager.runesCount.EarthRunesFound(_earthPuzzleChestAnimator.gameObject.transform.parent.gameObject);
		}

		if (_fireChestOpened == false)
		{
			// Makes fire chest appear when the runes are found
			_gameManager.runesCount.FireRunesFound(_firePuzzleChestAnimator.gameObject.transform.parent.gameObject);
		}
	}

	/// <summary>
	/// Activates when the player trigger the water puzzle chest
	/// Used on select entered event
	/// </summary>
	public void OpenWaterPuzzleChest()
	{
		if (_waterChestOpened == false)
		{
			// Open chest animation
			_waterPuzzleChestAnimator.SetTrigger("Open");
			// Wait for the open chest animation to stop playing
			StartCoroutine(WaitOpenChestAnim(_waterPuzzleChestAnimator, _waterSword));

			_waterChestOpened = true;
		}
	}

	/// <summary>
	/// Activates when the player trigger the earth puzzle chest
	/// Used on select entered event
	/// </summary>
	public void OpenEarthPuzzleChest()
	{
		if (_earthChestOpened == false)
		{
			// Open chest animation
			_earthPuzzleChestAnimator.SetTrigger("Open");
			// Wait for the open chest animation to stop playing
			StartCoroutine(WaitOpenChestAnim(_earthPuzzleChestAnimator, _earthSword));

			_earthChestOpened = true;
		}
	}

	/// <summary>
	/// Activates when the player trigger the fire puzzle chest
	/// Used on select entered event
	/// </summary>
	public void OpenFirePuzzleChest()
	{
		if (_fireChestOpened == false)
		{
			// Open chest animation
			_firePuzzleChestAnimator.SetTrigger("Open");
			// Wait for the open chest animation to stop playing
			StartCoroutine(WaitOpenChestAnim(_firePuzzleChestAnimator, _fireSword));

			_fireChestOpened = true;
		}
	}

	// Wait for the open chest animation to stop playing, then
	// Play open chest sfx and sword appears
	private IEnumerator WaitOpenChestAnim(Animator chestAnimator, GameObject sword)
	{
		AnimationClip[] animationClips = chestAnimator.runtimeAnimatorController.animationClips;
		// Open animation time
		float timeToWait = animationClips[2].length;

		// Audio source of the chest
		AudioSource audioSource = chestAnimator.transform.parent.gameObject.GetComponent<AudioSource>();

		// Wait for Open animation to finish
		yield return new WaitForSeconds(timeToWait);

		// Give open chest sfx clip
		audioSource.clip = _openChestSfx.clip;

		// Enable the audio source
		audioSource.enabled = true;

		// Sword appear after animation
		sword.SetActive(true);
	}

	/// <summary>
	/// Disable the right chest (when the sword is grabbed),
	/// depending of the sword name
	/// </summary>
	/// <param name="sword"></param>
	public void DisableChestSwordGrab(GameObject sword)
	{
		// Disable the right chest depending of the sword name
		// And open the corresponding doors
		switch (sword.name)
		{
			case "WaterSword":
				StartCoroutine(_gameManager.SmokeOnDisable(_waterPuzzleChestAnimator.transform.parent.gameObject));
				_gameManager.openCloseDoors.OpenWaterDoors();
				break;
			case "EarthSword":
				StartCoroutine(_gameManager.SmokeOnDisable(_earthPuzzleChestAnimator.transform.parent.gameObject));
				_gameManager.openCloseDoors.OpenEarthDoors();
				break;
			case "FireSword":
				StartCoroutine(_gameManager.SmokeOnDisable(_firePuzzleChestAnimator.transform.parent.gameObject));
				_gameManager.openCloseDoors.OpenFireDoors();
				break;
		}
	}
}
