using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;

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
	[SerializeField] private AudioSource _spawnChestSfx;
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
		RunesFound();
	}

	// Check if the runes are found
	private void RunesFound()
	{
		if (_waterChestOpened == false)
		{
			// Makes water chest appear when the runes are found
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
				_waterPuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				_gameManager.openCloseDoors.OpenWaterDoors();
				break;
			case "EarthSword":
				_firePuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				_gameManager.openCloseDoors.OpenEarthDoors();
				break;
			case "FireSword":
				_earthPuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				_gameManager.openCloseDoors.OpenFireDoors();
				break;
		}
	}

	// Add smoke when the chest appear and disappear, add smoke sound for both
}
