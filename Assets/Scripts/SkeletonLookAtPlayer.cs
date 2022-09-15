using UnityEngine;

/// <summary>
/// Sekeleton look at player in the dead scene
/// </summary>
public class SkeletonLookAtPlayer : MonoBehaviour
{
	[SerializeField] Transform player;

	// Update is called once per frame
	void Update()
	{
		this.transform.LookAt(player);
	}
}
