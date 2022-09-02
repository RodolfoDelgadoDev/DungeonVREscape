using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;

public class Chests : MonoBehaviour
{
	#region Variables
	#region Chests Variables
	[Header("Puzzle Chests Animators")]
	public Animator _waterPuzzleChestAnimator;
	public Animator _earthPuzzleChestAnimator;
	public Animator _firePuzzleChestAnimator;

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
	#endregion

	private void Update()
	{
		_gameManager.runesCount.WaterRunesFound(_waterPuzzleChestAnimator.gameObject.transform.parent.gameObject);

		//_waterSword.GetComponent<Swords>().GrabbedSword(_waterPuzzleChestAnimator);
	}

	/// <summary>
	/// Activates when the player trigger the water puzzle chest
	/// Used on first select entered event
	/// </summary>
	public void OpenWaterPuzzleChest()
	{
		// Open chest animation
		_waterPuzzleChestAnimator.SetTrigger("Open");
		// Wait for the open chest animation to stop playing
		StartCoroutine(WaitOpenChestAnim());
	}

	// Wait for the open chest animation to stop playing, then
	// Play open chest sfx and sword appears
	private IEnumerator WaitOpenChestAnim()
	{
		AnimationClip[] animationClips = _waterPuzzleChestAnimator.runtimeAnimatorController.animationClips;
		// Open animation time
		float timeToWait = animationClips[2].length;

		// Wait for Open animation to finish
		yield return new WaitForSeconds(timeToWait);

		// Chest sound for treasure
		_openChestSfx.enabled = true;
		// Sword appear after animation
		_waterSword.SetActive(true);
	}

	/// <summary>
	/// Disable the right chest depending of the sword name
	/// </summary>
	/// <param name="sword"></param>
	public void DisableChest(GameObject sword)
	{
		// Disable the right chest depending of the sword name
		switch (sword.name)
		{
			case "WaterSword":
				_waterPuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				break;
			case "FireSword":
				_firePuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				break;
			case "EarthSword":
				_earthPuzzleChestAnimator.transform.parent.gameObject.SetActive(false);
				break;
		}
	}

	// Find chest spawn sound, like wood sound or heavy wood sound or something popping
	// Open doors when a chest is disabled
}
