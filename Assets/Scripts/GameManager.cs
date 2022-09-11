using System.Collections;
using UnityEngine;

/// <summary>
/// Access to other scripts using only this one,
/// gives less variables to read and write
/// </summary>
public class GameManager : MonoBehaviour
{
	#region Runes Variables
	public WaterRuneTrigger waterRuneTrigger;
	public EarthRuneTrigger earthRuneTrigger;
	public FireRuneTrigger fireRuneTrigger;
	public RunesCount runesCount;
	#endregion
	public Chests chests;
	public OpenCloseDoors openCloseDoors;
	public GameObject smokeVfxGameObject;
	public AudioSource smokeSfx;

	/// <summary>
	/// Makes smoke appear where the GameObject go is,
	/// disable the go
	/// </summary>
	/// <param name="go">GameObject to instantiate smoke at</param>
	/// <returns></returns>
	public IEnumerator SmokeOnDisable(GameObject go)
	{
		ParticleSystem smokeVfx = smokeVfxGameObject.GetComponent<ParticleSystem>();
		Vector3 smokeSpawnPos = new Vector3(go.transform.position.x, go.transform.position.y + 0.26f, go.transform.position.z);

		Instantiate(smokeVfxGameObject, smokeSpawnPos, go.transform.rotation);
		smokeSfx.Play();

		yield return new WaitForSeconds(smokeVfx.main.duration / 1.5f);

		go.SetActive(false);
	}

	/// <summary>
	/// Makes smoke appear where the GameOject go is,
	/// spawn the go
	/// </summary>
	/// <param name="go">GameObject to instantiate smoke at</param>
	/// <returns></returns>
	public IEnumerator SmokeOnSpawn(GameObject go)
	{
		ParticleSystem smokeVfx = smokeVfxGameObject.GetComponent<ParticleSystem>();
		Vector3 smokeSpawnPos = new Vector3(go.transform.position.x, go.transform.position.y + 0.26f, go.transform.position.z);

		Instantiate(smokeVfxGameObject, smokeSpawnPos, go.transform.rotation);
		smokeSfx.Play();

		yield return new WaitForEndOfFrame();

		go.SetActive(true);
	}


}
